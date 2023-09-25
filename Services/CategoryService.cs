using System.Runtime.CompilerServices;
using market_place.Extensions;
using market_place.Models.Dto;
using market_place.Repository;

namespace market_place.Services;
public sealed class CategoryService
{
    private readonly CategoryRepository _repository;
    private readonly ILogger _logger;
    
    public CategoryService(CategoryRepository repository, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _repository = repository;
    }
    public async IAsyncEnumerable<CategoryInfo> GetAllCategoryAsync([EnumeratorCancellation] CancellationToken token = default)
    {
        await foreach (var category in _repository.GetAllAsync())
        {
            token.ThrowIfCancellationRequested();
            yield return category.ToCategoryInfo();
        }
    }
    public async Task<CategoryInfo> GetCategoryByIdAsync(int id, CancellationToken token = default)
    {
        var category = await _repository.GetByIdAsync(id, token);
        return category.ToCategoryInfo();
    }
    public async Task<CategoryCreateRes> InsertCategoryAsync(CategoryCreateReq req, CancellationToken token = default)
    {
        
        var category = req.ToCategory();
        
        await _repository.InsertAsync(category, token);

        return new ()
        {
            Id = category.Id
        };
    }
    public async Task<CategoryUpdateRes> UpdateCategoryAsync(CategoryUpdateReq req, CancellationToken token = default)
    {
        
        var category = await _repository.GetByIdAsync(req.Id, token);
        var prevName = category.Name;
        category.Name = req.Name;
        await _repository.UpdateAsync(category, token);

        return new()
        {
            Id = category.Id,
            PrevName = prevName,
            NewName = category.Name
        };
    }
    public async Task<CategoryDeleteRes> DeleteCategoryAsync(int id, CancellationToken token = default)
    {
        var category = await _repository.GetByIdAsync(id, token);
        category.IsDeleted = true;
        await _repository.SaveChangesAsync(token);

        return new()
        {
            Id = category.Id,
        };
    }
}