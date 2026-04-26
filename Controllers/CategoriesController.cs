using Majnuntol.Api.DTOs.Categories;
using Majnuntol.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Majnuntol.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/categories
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    // GET: api/categories/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        if (category is null)
            return NotFound(new { Message = $"Category topilmadi. Id: {id}" });

        return Ok(category);
    }

    // POST: api/categories
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _categoryService.CreateAsync(dto);

        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = created.CategoryId },
            value: created);
    }

    // PUT: api/categories/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CategoryCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _categoryService.UpdateAsync(id, dto);

        if (updated is null)
            return NotFound(new { Message = $"Category topilmadi. Id: {id}" });

        return Ok(updated);
    }

    // DELETE: api/categories/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _categoryService.DeleteAsync(id);

        if (!success)
            return NotFound(new { Message = $"Category topilmadi. Id: {id}" });

        return Ok(new { Message = "Category o'chirildi (soft delete)" });
    }
}