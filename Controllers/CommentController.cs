// As a reader, I would like to see a list of all the Comments on a Post so that I can read and take part in the discussion on a particular Post.

// Given the user is viewing the Details of a Post
// When they select the View Comments button
// Then they should be directed to the Comments list page for the Post
// And the list should be in order of creation date with the most recent on top
// And the title of the related Post should be displayed at the top of the page
// And a link back to the Post should be available

// Display the following information for each Comment

// Subject
// Content
// Author's Display Name
// Creation date (MM/DD/YYYY)

// create controller to get all comments for a post and related data
// create controller to get a single comment by id and related data
// create view to display all comments for a post
// create view to display a single comment

// Path: Controllers/CommentController.cs

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabloid.Data;

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
}