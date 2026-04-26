namespace Majnuntol.Api.DTOs.Categories;

/// <summary>
/// Admin yangi kategoriya yaratganda yuboradigan ma'lumotlar.
/// </summary>
public class CategoryCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
}