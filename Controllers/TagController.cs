using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tabloid.Data;

[ApiController]
[Route("api/[controller]")]

public class TagController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public TagController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Tags
        .OrderBy(t => t.Name)
       .ToList());
    }
}