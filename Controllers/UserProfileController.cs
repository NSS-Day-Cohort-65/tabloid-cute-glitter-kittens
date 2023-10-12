using Microsoft.AspNetCore.Mvc;
using Tabloid.Models;
using Tabloid.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public UserProfileController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    // get all user profiles which are active - currently unused

    [HttpGet]
    [Authorize]
    public IActionResult GetActive()
    {
        return Ok(_dbContext
            .UserProfiles
            .Where(up => up.IsActive == true)
            .ToList());
    }

    // get all user profiles, with details, which are active

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            IsActive = up.IsActive,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
           
        })
        .Where(up => up.IsActive == true)
        .OrderBy(up => up.UserName)
        );
    }

    [HttpGet("withroles/inactive")]
    // [Authorize(Roles = "Admin")]
    public IActionResult GetInactiveWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            IsActive = up.IsActive,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
           
        })
        .Where(up => up.IsActive == false)
        .OrderBy(up => up.UserName)
        );
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");

        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    // access certain user details by id; includes roles
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById(int id)
    {

        UserProfile foundUser = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfile
            {
                Id = up.Id,
                IdentityUserId = up.IdentityUserId,
                FirstName = up.FirstName,
                LastName = up.LastName,
                UserName = up.IdentityUser.UserName,
                Email = up.IdentityUser.Email,
                CreateDateTime = up.CreateDateTime,
                ImageLocation = up.ImageLocation,
                Roles = _dbContext.UserRoles
                .Where(ur => ur.UserId == up.IdentityUserId)
                .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name).ToList()
            })
        .SingleOrDefault(up => up.Id == id);
        
        if (foundUser == null)
        {
            return NotFound();
        }

        return Ok(foundUser);
    }

    // soft delete: deactivates given user by id
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeactivateById(int id)
    {
        UserProfile foundUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.Id == id);

        if (foundUser == null)
        {
            return NotFound();
        }

        foundUser.IsActive = false;

        _dbContext.SaveChanges();

        return NoContent();
    }

    // undo above soft delete: re-activates given user by Id
    [HttpDelete("{id}/reactivate")]
    // [Authorize(Roles = "Admin")]
    public IActionResult ReactivateById(int id)
    {
        UserProfile foundUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.Id == id);

        if (foundUser == null)
        {
            return NotFound();
        }

        foundUser.IsActive = true;

        _dbContext.SaveChanges();

        return NoContent();
    }
}