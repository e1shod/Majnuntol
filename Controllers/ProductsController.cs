using Microsoft.AspNetCore.Mvc;
using Majnuntol.Api.DTOs.Products;
using Majnuntol.Api.Services.Products;

namespace Majnuntol.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product is null)
            return NotFound(new { Message = $"Product topilmadi. Id: {id}" });

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _productService.CreateAsync(dto);

        if (created is null)
            return BadRequest(new
            {
                Message = "User yoki Category topilmadi. " +
                          "Avval mavjud UserId va CategoryId kiriting."
            });

        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = created.ProductId },
            value: created);
    }

    // PUT: api/products/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _productService.UpdateAsync(id, dto);

        if (updated is null)
            return NotFound(new { Message = $"Product topilmadi. Id: {id}" });

        return Ok(updated);
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _productService.DeleteAsync(id);

        if (!success)
            return NotFound(new { Message = $"Product topilmadi. Id: {id}" });

        return Ok(new { Message = "Product o'chirildi (Status = Deleted)." });
    }
}