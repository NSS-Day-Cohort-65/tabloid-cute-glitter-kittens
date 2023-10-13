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

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteCategory(int id)
    {
        Category foundCategory = _dbContext.Categories.SingleOrDefault(c => c.Id == id);
        
        if (foundCategory == null)
        {
            return NotFound();
        }

        // changes any related post with the above category id to categoryId == null.
        var relatedPosts = _dbContext
            .Posts
            .Where(pt => pt.CategoryId == id)
            .ToList();

        relatedPosts.ForEach(p => p.CategoryId = null);

        _dbContext.Categories.Remove(foundCategory);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
