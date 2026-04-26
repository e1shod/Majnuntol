namespace Majnuntol.Api.Entities;

/// <summary>
/// Xaridor sotuvchiga qoldirgan sharh va baho.
/// Rating: 1 dan 5 gacha.
/// </summary>
public class Review
{
    public Guid ReviewId { get; set; } = Guid.NewGuid();
    public Guid ReviewerUserId { get; set; }
    public Guid SellerUserId { get; set; }
    public int Rating { get; set; } = 0;
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}