using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            .Where(p => p.PublishDateTime < DateTime.Now)
            .ToList());
    }
}