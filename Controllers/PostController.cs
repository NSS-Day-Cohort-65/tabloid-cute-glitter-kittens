using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Tabloid.Data;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public PostController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    // get all posts, not including any with a publishDateTime in the future
    [HttpGet]
    [Authorize]
    public IActionResult Get(int? categoryId, int? tagId)
    {
        if(categoryId != null)
        {
            return Ok(_dbContext.Posts
            .Include(p => p.Category)
            .Include(p => p.UserProfile)
                .ThenInclude(up=>up.IdentityUser)
            .Where(p => p.CategoryId == categoryId)
            .Where(p => p.PublishDateTime < DateTime.Now)
            .ToList());
        } else if(tagId != null)
        {
            var postIdsWithGivenTag = _dbContext.PostTags
            .Where(pt => pt.TagId == tagId)
            .Select(pt => pt.PostId)
            .ToList();

            if(postIdsWithGivenTag.Count > 0)
            {
            return Ok(_dbContext.Posts
            .Include(p => p.Category)
            .Include(p => p.UserProfile)
                .ThenInclude(up => up.IdentityUser)
            .Where(p => p.PublishDateTime < DateTime.Now)
            .Where(p => postIdsWithGivenTag.Contains(p.Id)).ToList()); 
            } else {
                return NotFound();
            }
        }
        else {
            return Ok(_dbContext.Posts
            .Include(p => p.Category)
            .Include(p => p.UserProfile)
                .ThenInclude(up => up.IdentityUser)
            .Where(p => p.PublishDateTime < DateTime.Now)
            .ToList());
        }
        
    }

    // get post by Id, with UserProfile, then identityUser for Author's UserName
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetPostById(int id)
    {
        Post post = _dbContext.Posts
        .Include(p => p.UserProfile)
            .ThenInclude(up => up.IdentityUser)
        .SingleOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreatePost(Post post)
    {
        post.CreateDateTime = DateTime.Now;
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();
        return Created($"/api/post/{post.Id}", post);
    }

    [HttpDelete("{postId}")]
    [Authorize]
    public IActionResult DeletePost( int postId)
    {
        Post PostToDelete = _dbContext.Posts.SingleOrDefault(p => p.Id == postId);
        if (PostToDelete == null)
        {
            return NotFound();
        }
        else if (postId != PostToDelete.Id)
        {
            return BadRequest();
        }
        //delete comment for post
        var relatedComments = _dbContext.Comments.Where(c => c.PostId == postId);
        _dbContext.Comments.RemoveRange(relatedComments);

        //delete reactions for post
        var relatedReactions = _dbContext.PostReactions.Where(pr => pr.PostId == postId);
        _dbContext.PostReactions.RemoveRange(relatedReactions);

        //delete post tags
        var relatedTags = _dbContext.PostTags.Where(pt => pt.PostId == postId);
        _dbContext.PostTags.RemoveRange(relatedTags);

        _dbContext.Posts.Remove(PostToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }
}