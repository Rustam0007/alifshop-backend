using market_place.Data;
using market_place.Enums;
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

    public async Task<Response<IEnumerable<SubCategory>>> GetAllSubCategoryAsync()
    {
        var response = new Response<IEnumerable<SubCategory>>();
        try
        {
            var categories = await _repository.GetAllAsync<SubCategory>();
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = categories;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Subcategory");
        }
        return response;
    }
    public async Task<Response<SubCategory>> GetSubCategoryByIdAsync(int id)
    {
        var response = new Response<SubCategory>();
        try
        {
            var category = await _repository.GetByIdAsync<SubCategory>(id);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new SubCategory
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Subcategory");
        }
        return response;
    }
    public async Task<Response<SubCategoryCreateRes>> InsertSubCategoryAsync(SubCategoryCreateReq req)
    {
        var response = new Response<SubCategoryCreateRes>();
        try
        {
            var category = new SubCategory
            {
                Name = req.Name,
                CategoryId = req.CategoryId
            };
            await _repository.InsertAsync(category);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new SubCategoryCreateRes
            {
                Id = category.Id,
                Name = category.Name,
                CategoryId = category.CategoryId
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to insert Subcategory");
        }
        return response;
    }
    public async Task<Response<SubCategoryUpdateRes>> UpdateSubCategoryAsync(SubCategoryUpdateReq req)
    {
        var response = new Response<SubCategoryUpdateRes>();
        try
        {
            var category = await _repository.GetByIdAsync<SubCategory>(req.Id);
            var prevName = category.Name;
            category.Name = req.Name;
            category.CategoryId = req.CategoryId;
            await _repository.UpdateAsync(category);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new SubCategoryUpdateRes
            {
                Id = category.Id,
                PrevName = prevName,
                NewName = category.Name
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to update Subcategory");
        }
        return response;
    }
    public async Task<Response<SubCategoryDeleteRes>> DeleteSubCategoryAsync(int id)
    {
        var response = new Response<SubCategoryDeleteRes>();
        try
        {
            var category = await _repository.GetByIdAsync<SubCategory>(id);
            category.IsDeleted = true;
            var res = await _repository.SaveChangesAsync();

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new SubCategoryDeleteRes
            {
                Id = category.Id,
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to delete category");
        }
        return response;
    }
}