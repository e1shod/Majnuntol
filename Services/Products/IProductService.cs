using Majnuntol.Api.DTOs.Products;

namespace Majnuntol.Api.Services.Products;

public interface IProductService
{
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto?> GetByIdAsync(Guid id);
    Task<ProductGetDto?> CreateAsync(ProductCreateDto dto);
    Task<ProductGetDto?> UpdateAsync(Guid id, ProductUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}