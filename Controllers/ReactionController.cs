using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabloid.Data;

[ApiController]
[Route("api/[controller]")]
public class ReactionController : ControllerBase
{
    private TabloidDbContext _dbcontext;

    public ReactionController(TabloidDbContext context)
    {
        _dbcontext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbcontext
        .Reactions.ToList());
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateReaction(Reaction reaction)
    {
        _dbcontext.Reactions.Add(reaction);
        _dbcontext.SaveChanges();
        return Created($"/api/reactions/{reaction.Id}", reaction);
    }
}