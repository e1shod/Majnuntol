namespace Majnuntol.Api.DTOs.Users;

/// <summary>
/// Foydalanuvchi ma'lumotlarini clientga qaytarish uchun.
/// PasswordHash hech qachon clientga yuborilmaydi — shu yerda yo'q.
/// </summary>
public class UserGetDto
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}