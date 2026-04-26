namespace Majnuntol.Api.DTOs.Reviews;

/// <summary>
/// Sharh ma'lumotlarini clientga qaytarish uchun.
/// </summary>
public class ReviewGetDto
{
    public Guid ReviewId { get; set; }
    public Guid ReviewerUserId { get; set; }
    public Guid SellerUserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}