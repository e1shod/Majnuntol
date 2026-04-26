using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Majnuntol.Api.Data;
using Majnuntol.Api.DTOs.Auth;
using Majnuntol.Api.Entities;
using Majnuntol.Api.Settings;

namespace Majnuntol.Api.Services.Auth;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly JwtSettings _jwtSettings;
    private readonly PasswordHasher<User> _passwordHasher;

    public AuthService(AppDbContext context, JwtSettings jwtSettings)
    {
        _context = context;
        _jwtSettings = jwtSettings;
        _passwordHasher = new PasswordHasher<User>();
    }

    // ── REGISTER ──────────────────────────────────────────────
    public async Task<AuthResponseDto?> RegisterAsync(RegisterDto dto)
    {
        // Email unique tekshiruvi
        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == dto.Email);

        if (emailExists)
            return null;

        // PhoneNumber unique tekshiruvi
        var phoneExists = await _context.Users
            .AnyAsync(u => u.PhoneNumber == dto.PhoneNumber);

        if (phoneExists)
            return null;

        // Yangi User yaratish
        var user = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Role = "User",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Password hash qilish
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var token = GenerateToken(user);

        return MapToDto(user, token);
    }

    // ── LOGIN ─────────────────────────────────────────────────
    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        // Email bo'yicha user topish
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user is null)
            return null;

        // Password tekshiruvi
        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            dto.Password);

        if (result == PasswordVerificationResult.Failed)
            return null;

        var token = GenerateToken(user);

        return MapToDto(user, token);
    }

    // ── JWT TOKEN GENERATOR ───────────────────────────────────
    private string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email,          user.Email),
            new Claim(ClaimTypes.Role,           user.Role),
            new Claim(ClaimTypes.Name,           $"{user.FirstName} {user.LastName}")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // ── MAPPER ────────────────────────────────────────────────
    private static AuthResponseDto MapToDto(User user, string token) => new AuthResponseDto
    {
        UserId = user.UserId,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        PhoneNumber = user.PhoneNumber,
        Role = user.Role,
        Token = token
    };
}