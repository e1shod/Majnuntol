using Microsoft.EntityFrameworkCore;
using Majnuntol.Api.Data;
using Majnuntol.Api.DTOs.Categories;
using Majnuntol.Api.Entities;

namespace Majnuntol.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    // ── GET ALL ───────────────────────────────────────────────
    public async Task<List<CategoryGetDto>> GetAllAsync()
    {
        return await _context.Categories
            .Where(c => c.IsActive)
            .Select(c => ToDto(c))
            .ToListAsync();
    }

    // ── GET BY ID ─────────────────────────────────────────────
    public async Task<CategoryGetDto?> GetByIdAsync(Guid id)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id && c.IsActive);

        return category is null ? null : ToDto(category);
    }

    // ── CREATE ────────────────────────────────────────────────
    public async Task<CategoryGetDto> CreateAsync(CategoryCreateDto dto)
    {
        var category = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = dto.Name,
            IconUrl = dto.IconUrl,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return ToDto(category);
    }

    // ── UPDATE ────────────────────────────────────────────────
    public async Task<CategoryGetDto?> UpdateAsync(Guid id, CategoryCreateDto dto)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id && c.IsActive);

        if (category is null) return null;

        category.Name = dto.Name;
        category.IconUrl = dto.IconUrl;

        await _context.SaveChangesAsync();

        return ToDto(category);
    }

    // ── DELETE (Soft delete) ──────────────────────────────────
    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id && c.IsActive);

        if (category is null) return false;

        category.IsActive = false;
        await _context.SaveChangesAsync();

        return true;
    }

    // ── HELPER ────────────────────────────────────────────────
    private static CategoryGetDto ToDto(Category c) => new()
    {
        CategoryId = c.CategoryId,
        Name = c.Name,
        IconUrl = c.IconUrl,
        IsActive = c.IsActive,
        CreatedAt = c.CreatedAt
    };
}