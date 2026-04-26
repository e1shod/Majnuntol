namespace Majnuntol.Api.Entities;

/// <summary>
/// Tizimga ro'yxatdan o'tgan har qanday foydalanuvchi.
/// Role bo'yicha: oddiy user, sotuvchi, admin, vet, mutaxassis, ishchi.
/// </summary>
public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Qiymatlar: User | Seller | Admin | Vet | Specialist | Worker
    /// </summary>
    public string Role { get; set; } = "User";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}