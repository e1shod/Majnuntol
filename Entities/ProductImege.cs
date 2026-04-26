namespace Majnuntol.Api.Entities;

/// <summary>
/// Mahsulotga tegishli rasmlar.
/// Bitta mahsulotda bir nechta rasm bo'lishi mumkin.
/// IsMain = true bo'lgan rasm asosiy (thumbnail) sifatida ko'rsatiladi.
/// </summary>
public class ProductImage
{
    public Guid ProductImageId { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}