using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;

namespace Tabloid.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

    public TabloidDbContext _dbContext { get; set; }

    public CategoryController(TabloidDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        
        var categories = _dbContext.Categories.OrderBy(c => c.Name).ToList();
        return Ok(categories);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        return Created($"/api/categories/{category.Id}", category);
    }
}
