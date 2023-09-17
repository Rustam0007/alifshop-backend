using market_place.Models;
using market_place.Models.Dto;
using market_place.Services;
using Microsoft.AspNetCore.Mvc;

namespace market_place.Controllers;

[ApiController]
[Route("subCategory")]
public class SubCategoryController : ControllerBase
{
    private readonly SubCategoryService _subCategoryService;
    public SubCategoryController(SubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }
    [HttpGet]
    public async Task<Response<IEnumerable<SubCategory>>> GetAllSubCategory()
    {
        return await _subCategoryService.GetAllSubCategoryAsync();
    }
    [HttpGet("{id:int}")]
    public async Task<Response<SubCategory>> GetSubCategoryById(int id)
    {
        return await _subCategoryService.GetSubCategoryByIdAsync(id);
    }
    [HttpGet("by-categoryId/{id:int}")]
    public async Task<Response<List<SubCategory>>> GetSubCategoryByCategoryId(int id)
    {
        return await _subCategoryService.GetSubCategoryByCategoryIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<SubCategoryCreateRes>> InsertSubCategory([FromBody] SubCategoryCreateReq req)
    {
        return await _subCategoryService.InsertSubCategoryAsync(req);
    }
    [HttpPatch]
    public async Task<Response<SubCategoryUpdateRes>> UpdateSubCategory([FromBody] SubCategoryUpdateReq req)
    {
        return await _subCategoryService.UpdateSubCategoryAsync(req);
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<SubCategoryDeleteRes>> DeleteSubCategory(int id)
    {
        return await _subCategoryService.DeleteSubCategoryAsync(id);
    }
}