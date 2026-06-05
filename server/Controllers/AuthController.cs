using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Auth;
using server.Entities;
using server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext  _db;
    private readonly ITokenService _tokenService;

    public AuthController(AppDbContext db, ITokenService tokenService)
    {
        _db           = db;
        _tokenService = tokenService;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegisterRequest req)
    {
        
        if (await _db.Users.AnyAsync(u => u.Email == req.Email))
            return BadRequest("Email already in use.");

        if (await _db.Users.AnyAsync(u => u.Username == req.Username))
            return BadRequest("Username already taken.");

        var user = new User
        {
            Id           = Guid.NewGuid(),
            Username     = req.Username,
            Email        = req.Email,
            DisplayName  = req.DisplayName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Ok(new AuthResponse
        {
            Token       = _tokenService.CreateToken(user),
            Username    = user.Username,
            DisplayName = user.DisplayName,
            Email       = user.Email,
        });
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest req)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == req.Email);

        if (user is null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials.");

        if (!user.IsActive)
            return Unauthorized("Account is disabled.");

        return Ok(new AuthResponse
        {
            Token       = _tokenService.CreateToken(user),
            Username    = user.Username,
            DisplayName = user.DisplayName,
            Email       = user.Email,
        });
    }
    
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _db.Users.FindAsync(Guid.Parse(userId!));

        if (user is null) return NotFound();

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Email,
            user.DisplayName,
            user.CreatedAt
        });
    }
}

