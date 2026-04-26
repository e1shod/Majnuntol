namespace Majnuntol.Api.DTOs.Products;

/// <summary>
/// Sotuvchi yangi e'lon yaratganda yuboradigan ma'lumotlar.
/// Status, ViewCount, LikeCount server tomonida o'rnatiladi — bu yerda yo'q.
/// </summary>
public class ProductCreateDto
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
}