namespace Majnuntol.Api.DTOs.Categories;

/// <summary>
/// Kategoriya ro'yxatini clientga qaytarish uchun.
/// </summary>
public class CategoryGetDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}