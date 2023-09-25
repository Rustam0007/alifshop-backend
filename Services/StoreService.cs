using System.Runtime.CompilerServices;
using market_place.Extensions;
using market_place.Models.Dto;
using market_place.Repository;

namespace market_place.Services;
public class StoreService
{
    private readonly StoreRepository _repository;
    private readonly ILogger _logger;
    
    public StoreService(StoreRepository repository, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _repository = repository;
    }

    public async IAsyncEnumerable<StoreInfo> GetAllStoreAsync([EnumeratorCancellation] CancellationToken token = default)
    {
        await foreach (var category in _repository.GetAllAsync())
        {
            token.ThrowIfCancellationRequested();
            yield return category.ToStoreInfo();
        }
    }
    public async Task<StoreInfo> GetStoreByIdAsync(int id, CancellationToken token = default)
    {
        var store = await _repository.GetByIdAsync(id, token);
        return store.ToStoreInfo();
    }
    
    public async Task<StoreCreateRes> InsertStoreAsync(StoreCreateReq req, CancellationToken token = default)
    {
        
        var store = req.ToStore();
        
        await _repository.InsertAsync(store, token);

        return new ()
        {
            Id = store.Id
        };
    }
    
    public async Task<StoreUpdateRes> UpdateStoreAsync(StoreUpdateReq req, CancellationToken token = default)
    {
        
        var store = await _repository.GetByIdAsync(req.Id, token);
        var prevName = store.Name;
        store.Name = req.Name;
        await _repository.UpdateAsync(store, token);

        return new()
        {
            Id = store.Id,
            PrevName = prevName,
            NewName = store.Name
        };
    }
    public async Task<StoreDeleteRes> DeleteStoreAsync(int id, CancellationToken token = default)
    {
        var store = await _repository.GetByIdAsync(id, token);
        store.IsDeleted = true;
        await _repository.SaveChangesAsync(token);

        return new()
        {
            Id = store.Id,
        };
    }
}