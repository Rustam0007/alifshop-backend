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
    public async Task<Response<IEnumerable<Store>>> GetAllStore()
    {
        return await _storeService.GetAllStoreAsync();
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Store>> GetStoreById(int id)
    {
        return await _storeService.GetStoreByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<StoreCreateRes>> InsertStore([FromBody] StoreCreateReq req)
    {
        return await _storeService.InsertStoreAsync(req);
    }
    [HttpPatch]
    public async Task<Response<StoreUpdateRes>> InsertStore([FromBody] StoreUpdateReq req)
    {
        return await _storeService.UpdateStoreAsync(req);
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<StoreDeleteRes>> DeleteStore(int id)
    {
        return await _storeService.DeleteStoreAsync(id);
    }
}