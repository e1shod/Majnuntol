using System.ComponentModel.DataAnnotations.Schema;  // ← BU QO'SHING

namespace Majnuntol.Api.Entities;

public class Product
{
    public Guid ProductId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]   // ← BU QO'SHING
    public decimal Price { get; set; }

    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public bool IsPremium { get; set; } = false;
    public int ViewCount { get; set; } = 0;
    public int LikeCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}