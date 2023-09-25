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
    public IAsyncEnumerable<SubCategoryInfo> GetAllSubCategory()
    {
        return _subCategoryService.GetAllSubCategoryAsync();
    }
    [HttpGet("{id:int}")]
    public Task<SubCategoryInfo> GetSubCategoryById(int id)
    {
        return _subCategoryService.GetSubCategoryByIdAsync(id);
    }
    
    [HttpGet("by-categoryId/{id:int}")]
    public Task<List<SubCategory>> GetSubCategoryByCategoryId(int id)
    {
        return _subCategoryService.GetSubCategoryByCategoryIdAsync(id);
    }
    [HttpPost]
    public Task<SubCategoryCreateRes> InsertSubCategory([FromBody] SubCategoryCreateReq req)
    {
        return _subCategoryService.InsertSubCategoryAsync(req);
    }
    [HttpPatch]
    public Task<SubCategoryUpdateRes> UpdateSubCategory([FromBody] SubCategoryUpdateReq req)
    {
        return _subCategoryService.UpdateSubCategoryAsync(req);
    }
    [HttpDelete("{id:int}")]
    public Task<SubCategoryDeleteRes> DeleteSubCategory(int id)
    {
        return _subCategoryService.DeleteSubCategoryAsync(id);
    }
}