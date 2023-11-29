using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gladiator.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RiteshDbContext _context;

    public AuthController(RiteshDbContext context)
    {
        _context = context;
    }

    // POST: api/Auth/register
    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Login), new { id = user.UserID }, user);
    }

    // POST: api/Auth/login
    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var existingUser = _context.Users
            .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

        if (existingUser == null)
        {
            return NotFound("Invalid email or password");
        }

        return Ok(existingUser);
    }
}
