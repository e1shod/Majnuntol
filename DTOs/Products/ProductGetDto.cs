namespace Majnuntol.Api.DTOs.Products;

/// <summary>
/// E'lon ma'lumotlarini clientga qaytarish uchun.
/// </summary>


public class ProductGetDto
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsPremium { get; set; }
    public int ViewCount { get; set; }
    public int LikeCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}