using System.Security.Claims;
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

    [HttpPost("post/{postId}")]
    [Authorize]
    public IActionResult CreateNewComment(int postId, Comment comment)
    {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserProfile userProfile = _dbContext.UserProfiles
                .SingleOrDefault(up => up.IdentityUserId == userId);

            if (userProfile == null)
            {
                return NotFound();
            }

        Post post = _dbContext.Posts
        .Include(p => p.Comments)
        .ThenInclude(c => c.UserProfile)
        .Include(p => p.UserProfile)
        .SingleOrDefault(p => p.Id == postId);

        if (post == null)
        {
            return NotFound();
        }

        comment.PostId = postId;
        comment.CreateDateTime = DateTime.Now;
        comment.UserProfileId = userProfile.Id;
        comment.UserProfile = userProfile;

        _dbContext.Comments.Add(comment);
        _dbContext.SaveChanges();

        return Ok(comment);
    }
}