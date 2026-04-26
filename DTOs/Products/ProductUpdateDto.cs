namespace Majnuntol.Api.DTOs.Products;

/// <summary>
/// Sotuvchi e'lonni tahrirlaganda yuboradigan ma'lumotlar.
/// Faqat tahrirlash mumkin bo'lgan fieldlar bor.
/// UserId, CategoryId, Status o'zgartirilmaydi.
/// </summary>
public class ProductUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
}