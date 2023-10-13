using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabloid.Data;
using Tabloid.Models;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private TabloidDbContext _dbContext;
    public CommentController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("post/{postId}")]
    [Authorize]
    public IActionResult GetCommentsForPost(int postId)
    {
        Post post = _dbContext.Posts
        .Include(p => p.Comments)
        .Include(p => p.UserProfile)
        .SingleOrDefault(p => p.Id == postId);

        if (post == null)
        {
            return NotFound();
        }

        var comments = post.Comments.OrderByDescending(c => c.CreateDateTime).ToList();
        return Ok(comments);
    }

    [HttpPost("post/{postId}/comments")]
    [Authorize]
    public IActionResult CreateNewComment(int postId, Comment comment)
    {
        Post post = _dbContext.Posts
        .Include(p => p.Comments)
        .SingleOrDefault(p => p.Id == postId);


        if (post == null)
        {
            return NotFound();
        }
        comment.CreateDateTime = DateTime.Now;

        post.Comments.Add(comment);

        _dbContext.SaveChanges();
        return NoContent();
    }
}