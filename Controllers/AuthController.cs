using Microsoft.AspNetCore.Mvc;
using Majnuntol.Api.DTOs.Auth;
using Majnuntol.Api.Services.Auth;

namespace Majnuntol.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        if (result is null)
            return BadRequest(new { Message = "Email yoki telefon allaqachon mavjud." });
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        if (result is null)
            return Unauthorized(new { Message = "Email yoki parol noto'g'ri." });
        return Ok(result);
    }
}