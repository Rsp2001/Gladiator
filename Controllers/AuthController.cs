using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gladiator.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly GDbContext _context;

    public AuthController(GDbContext context)
    {
        _context = context;
    }

    // POST: api/Auth/register
    [HttpPost("register")]
    public IActionResult Register(UserCredentials user)
    {
        _context.UserCredentials.Add(user);
        _context.SaveChanges();

        return Ok(new { Message = "Registration successful" });
    }

    // POST: api/Auth/login
    [HttpPost("login")]
    public IActionResult Login(UserCredentials user)
    {
        var existingUser = _context.UserCredentials.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        if (existingUser == null)
        {
            return Unauthorized(new { Message = "Invalid username or password" });
        }

        // You can generate a token here and return it if needed

        return Ok(new { Message = "Login successful" });
    }
}
