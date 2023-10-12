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

      // post a new tag
    [HttpPost] // /api/tag/
    [Authorize]
    public IActionResult CreateTag([FromBody] Tag tag)
    {
        // add request validation
        if (tag == null)
        {
            return BadRequest("Invalid tag data.");
        }

        // Further validation to check if a tag with the same name already exists
        var existingTag = _dbContext.Tags.FirstOrDefault(c => c.Name == tag.Name);
        if (existingTag != null)
        {
            return BadRequest(new { error = "A tag with the same name already exists." });
        }

        // Error Handling
        try
        {
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();

            return Created($"/api/tag/{tag.Id}", tag);
        }
        catch (Exception ex)
        {
            // Log the exception and return an appropriate error response.
            return StatusCode(500, "An error occurred while creating the tag.");
        }
    }

}