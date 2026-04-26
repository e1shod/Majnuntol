namespace Majnuntol.Api.Entities;

/// <summary>
/// Sotuvchi bo'lgan User ning do'kon profili.
/// Har bir Seller uchun bitta SellerProfile bo'ladi.
/// </summary>
public class SellerProfile
{
    public Guid SellerProfileId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }

    public string ShopName { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }
    public string? Telegram { get; set; }
    public string? Instagram { get; set; }

    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string WorkingHours { get; set; } = string.Empty;

    public double Rating { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}