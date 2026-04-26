namespace Majnuntol.Api.DTOs.Users;

/// <summary>
/// Yangi foydalanuvchi ro'yxatdan o'tganda qabul qilinadigan ma'lumotlar.
/// Password shu yerda keladi — Service ichida hash ga aylantiriladi.
/// </summary>
public class UserCreateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}