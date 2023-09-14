using market_place.Enums;
using market_place.Models;
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

    public async Task<Response<IEnumerable<Store>>> GetAllStoreAsync()
    {
        var response = new Response<IEnumerable<Store>>();
        try
        {
            var stories = await _repository.GetAllAsync<Store>();
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = stories;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Store");
        }
        return response;
    }
    public async Task<Response<Store>> GetStoreByIdAsync(int id)
    {
        var response = new Response<Store>();
        try
        {
            var store = await _repository.GetByIdAsync<Store>(id);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new Store
            {
                Id = store.Id,
                Name = store.Name,
                IsDeleted = store.IsDeleted,
                Description = store.Description,
                Image = store.Image,
                Latitude = store.Latitude,
                Longitude = store.Longitude,
                PhoneNumber = store.PhoneNumber,
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Store");
        }
        return response;
    }
    public async Task<Response<StoreCreateRes>> InsertStoreAsync(StoreCreateReq req)
    {
        var response = new Response<StoreCreateRes>();
        try
        {
            var store = new Store
            {
                Name = req.Name,
                Description = req.Description,
                Image = req.Image,
                Latitude = req.Latitude,
                Longitude = req.Longitude,
                PhoneNumber = req.PhoneNumber,
                IsDeleted = false,
            };
            await _repository.InsertAsync(store);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new StoreCreateRes
            {
                Id = store.Id
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to insert Store");
        }
        return response;
    }
    public async Task<Response<StoreUpdateRes>> UpdateStoreAsync(StoreUpdateReq req)
    {
        var response = new Response<StoreUpdateRes>();
        try
        {
            var store = await _repository.GetByIdAsync<Store>(req.Id);
            store.Name = req.Name;
            store.Description = req.Description;
            store.Image = req.Image;
            store.Latitude = req.Latitude;
            store.Longitude = req.Longitude;
            store.PhoneNumber = req.PhoneNumber;
            
            await _repository.UpdateAsync(store);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new StoreUpdateRes
            {
                Id = store.Id
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to update Store");
        }
        return response;
    }
    public async Task<Response<StoreDeleteRes>> DeleteStoreAsync(int id)
    {
        var response = new Response<StoreDeleteRes>();
        try
        {
            var store = await _repository.GetByIdAsync<Store>(id);
            store.IsDeleted = true;
            await _repository.SaveChangesAsync();
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new StoreDeleteRes
            {
                Id = store.Id,
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to delete Store");
        }
        return response;
    }
}