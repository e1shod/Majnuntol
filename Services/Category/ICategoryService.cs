using Majnuntol.Api.DTOs.Categories;

namespace Majnuntol.Api.Services;

public interface ICategoryService
{
    Task<List<CategoryGetDto>> GetAllAsync();
    Task<CategoryGetDto?> GetByIdAsync(Guid id);
    Task<CategoryGetDto> CreateAsync(CategoryCreateDto dto);
    Task<CategoryGetDto?> UpdateAsync(Guid id, CategoryCreateDto dto);
    Task<bool> DeleteAsync(Guid id);
}