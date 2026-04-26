namespace Majnuntol.Api.Entities;

/// <summary>
/// Foydalanuvchining "Sevimlilari" ro'yxati.
/// User biror mahsulotni like / saqladi — shu yerda saqlanadi.
/// </summary>
public class Wishlist
{
    public Guid WishlistId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}