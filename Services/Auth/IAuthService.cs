using Majnuntol.Api.DTOs.Auth;

namespace Majnuntol.Api.Services.Auth;

public interface IAuthService
{
    Task<AuthResponseDto?> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto?> LoginAsync(LoginDto dto);
}