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
    public IActionResult Get()
    {
        return Ok(_dbContext.Posts
            .Include(p => p.Category)
            .Include(p => p.UserProfile)
                .ThenInclude(up=>up.IdentityUser)
            .Where(p => p.PublishDateTime < DateTime.Now)
            .ToList());
    }

    // get post by Id, with UserProfile, then identityUser for Author's UserName
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetPostById(int id)
    {
        Post post = _dbContext.Posts
        .Include(p => p.UserProfile)
            .ThenInclude(up=>up.IdentityUser)
        .SingleOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }
}