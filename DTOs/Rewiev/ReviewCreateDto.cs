namespace Majnuntol.Api.DTOs.Reviews;

/// <summary>
/// Xaridor sotuvchiga sharh qoldirganda yuboradigan ma'lumotlar.
/// </summary>
public class ReviewCreateDto
{
    public Guid ReviewerUserId { get; set; }
    public Guid SellerUserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}