using AuthService.Data;
using AuthService.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserAuthService _authService;

    public AuthController(UserAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        await _authService.Register(dto);
        return Ok("User registered");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _authService.Login(dto);
        return Ok(new { token });
    }


    [Authorize]
    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser()
    {
        var email = User.Identity?.Name;

        if (email == null)
            return Unauthorized();

        var user = await _authService.GetUserByEmailAsync(email);

        if (user == null)
            return NotFound("User not found");

        return Ok(new
        {
            user.FirstName,
            user.LastName,
            user.Email
        });
    }
}