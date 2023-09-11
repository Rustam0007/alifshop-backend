using market_place.Migrations;
using market_place.Models.Dto;
using market_place.Services;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<Response<IEnumerable<Category>>> GetAllCategory()
    {
        return await _categoryService.GetAllCategoryAsync();
    }
    [HttpGet("{id}")]
    public async Task<Response<Category>> GetCategoryById(int id)
    {
        return await _categoryService.GetCategoryByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<CategoryCreateRes>> InsertCategory([FromBody] CategoryCreateReq req)
    {
        return await _categoryService.InsertCategoryAsync(req);
    }
}