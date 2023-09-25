using System.Runtime.CompilerServices;
using market_place.Enums;
using market_place.Extensions;
using market_place.Models;
using market_place.Models.Dto;
using market_place.Repository;

namespace market_place.Services;

public class SubCategoryService
{
    private readonly SubCategoryRepository _repository;
    private readonly ILogger _logger;
    
    public SubCategoryService(SubCategoryRepository repository, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _repository = repository;
    }
    public async IAsyncEnumerable<SubCategoryInfo> GetAllSubCategoryAsync([EnumeratorCancellation] CancellationToken token = default)
    {
        await foreach (var subCategory in _repository.GetAllAsync())
        {
            token.ThrowIfCancellationRequested();
            yield return subCategory.ToSubCategoryInfo();
        }
    }
    public async Task<SubCategoryInfo> GetSubCategoryByIdAsync(int id, CancellationToken token = default)
    {
        var subCategory = await _repository.GetByIdAsync(id, token);
        return subCategory.ToSubCategoryInfo();
    }
    
    public async Task<List<SubCategory>> GetSubCategoryByCategoryIdAsync(int id, CancellationToken token = default)
    {
        var subCategory = await _repository.GetSubCategoryByCategoryId(id, token);
        return subCategory;
    }
    
    public async Task<SubCategoryCreateRes> InsertSubCategoryAsync(SubCategoryCreateReq req, CancellationToken token = default)
    {
        
        var subCategory = req.ToSubCategory();
        
        await _repository.InsertAsync(subCategory, token);

        return new ()
        {
            Id = subCategory.Id
        };
    }
    public async Task<SubCategoryUpdateRes> UpdateSubCategoryAsync(SubCategoryUpdateReq req, CancellationToken token = default)
    {
        
        var subCategory = await _repository.GetByIdAsync(req.Id, token);
        var prevName = subCategory.Name;
        subCategory.Name = req.Name;
        await _repository.UpdateAsync(subCategory, token);

        return new()
        {
            Id = subCategory.Id,
            PrevName = prevName,
            NewName = subCategory.Name
        };
    }
    public async Task<SubCategoryDeleteRes> DeleteSubCategoryAsync(int id, CancellationToken token = default)
    {
        var subCategory = await _repository.GetByIdAsync(id, token);
        subCategory.IsDeleted = true;
        await _repository.SaveChangesAsync(token);

        return new()
        {
            Id = subCategory.Id,
        };
    }
}