namespace Majnuntol.Api.Entities;

/// <summary>
/// Mahsulot kategoriyalari.
/// Misol: Chorva, Parranda, O'simlik, Vet xizmatlar,
///        Texnika, Ishchilar, Mutaxassislar, Don mahsulotlari, Arenda
/// </summary>
public class Category
{
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}