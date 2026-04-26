using Microsoft.EntityFrameworkCore;
using Majnuntol.Api.Data;
using Majnuntol.Api.DTOs.Products;
using Majnuntol.Api.Entities;

namespace Majnuntol.Api.Services.Products;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // ── GET ALL ───────────────────────────────────────────────
    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        return await _context.Products
            .Where(p => p.Status != "Deleted")
            .Select(p => MapToDto(p))
            .ToListAsync();
    }

    // ── GET BY ID ─────────────────────────────────────────────
    public async Task<ProductGetDto?> GetByIdAsync(Guid id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id && p.Status != "Deleted");

        if (product is null)
            return null;

        return MapToDto(product);
    }

    // ── CREATE ────────────────────────────────────────────────
    public async Task<ProductGetDto?> CreateAsync(ProductCreateDto dto)
    {
        // User mavjudligini tekshirish
        var userExists = await _context.Users
            .AnyAsync(u => u.UserId == dto.UserId);

        if (!userExists)
            return null;

        // Category mavjudligini tekshirish
        var categoryExists = await _context.Categories
            .AnyAsync(c => c.CategoryId == dto.CategoryId && c.IsActive);

        if (!categoryExists)
            return null;

        var product = new Product
        {
            ProductId = Guid.NewGuid(),
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            Region = dto.Region,
            District = dto.District,
            Status = "Pending",
            IsPremium = false,
            ViewCount = 0,
            LikeCount = 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return MapToDto(product);
    }

    // ── UPDATE ────────────────────────────────────────────────
    public async Task<ProductGetDto?> UpdateAsync(Guid id, ProductUpdateDto dto)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id && p.Status != "Deleted");

        if (product is null)
            return null;

        product.Title = dto.Title;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Region = dto.Region;
        product.District = dto.District;
        product.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return MapToDto(product);
    }

    // ── DELETE (Soft Delete) ──────────────────────────────────
    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id && p.Status != "Deleted");

        if (product is null)
            return false;

        product.Status = "Deleted";
        product.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    // ── MAPPER ────────────────────────────────────────────────
    private static ProductGetDto MapToDto(Product p) => new ProductGetDto
    {
        ProductId = p.ProductId,
        UserId = p.UserId,
        CategoryId = p.CategoryId,
        Title = p.Title,
        Description = p.Description,
        Price = p.Price,
        Region = p.Region,
        District = p.District,
        Status = p.Status,
        IsPremium = p.IsPremium,
        ViewCount = p.ViewCount,
        LikeCount = p.LikeCount,
        CreatedAt = p.CreatedAt,
        UpdatedAt = p.UpdatedAt   // ← qo'shildi
    };
}