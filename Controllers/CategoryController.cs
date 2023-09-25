using market_place.Models.Dto;
using market_place.Services;
using Microsoft.AspNetCore.Mvc;
using Category = market_place.Models.Category;

namespace market_place.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;
    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IAsyncEnumerable<CategoryInfo> GetAllCategory(CancellationToken token)
    {
        return _categoryService.GetAllCategoryAsync(token);
    }
    [HttpGet("{id:int}")]
    public Task<CategoryInfo> GetCategoryById(int id)
    {
        return _categoryService.GetCategoryByIdAsync(id);
    }
    [HttpPost]
    public Task<CategoryCreateRes> InsertCategory([FromBody] CategoryCreateReq req, CancellationToken token)
    {
        return _categoryService.InsertCategoryAsync(req, token);
    }
    [HttpPatch]
    public Task<CategoryUpdateRes> InsertCategory([FromBody] CategoryUpdateReq req, CancellationToken token)
    {
        return _categoryService.UpdateCategoryAsync(req, token);
    }
    [HttpDelete("{id:int}")]
    public Task<CategoryDeleteRes> DeleteCategory(int id, CancellationToken token)
    {
        return _categoryService.DeleteCategoryAsync(id, token);
    }
}