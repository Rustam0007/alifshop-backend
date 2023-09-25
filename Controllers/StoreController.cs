using market_place.Models;
using market_place.Models.Dto;
using market_place.Services;
using Microsoft.AspNetCore.Mvc;
using Store = market_place.Models.Store;

namespace market_place.Controllers;

[ApiController]
[Route("store")]
public class StoreController : ControllerBase
{
    private readonly StoreService _storeService;
    public StoreController(StoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public IAsyncEnumerable<StoreInfo> GetAllStore(CancellationToken token)
    {
        return _storeService.GetAllStoreAsync(token);
    }
    [HttpGet("{id:int}")]
    public Task<StoreInfo> GetStoreById(int id, CancellationToken token)
    {
        return _storeService.GetStoreByIdAsync(id, token);
    }
    [HttpPost]
    public Task<StoreCreateRes> InsertStore([FromBody] StoreCreateReq req, CancellationToken token)
    {
        return _storeService.InsertStoreAsync(req, token);
    }
    [HttpPatch]
    public Task<StoreUpdateRes> InsertStore([FromBody] StoreUpdateReq req, CancellationToken token)
    {
        return _storeService.UpdateStoreAsync(req, token);
    }
    [HttpDelete("{id:int}")]
    public Task<StoreDeleteRes> DeleteStore(int id, CancellationToken token)
    {
        return _storeService.DeleteStoreAsync(id, token);
    }
}