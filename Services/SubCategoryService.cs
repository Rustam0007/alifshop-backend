﻿using market_place.Data;
using market_place.Enums;
using market_place.Models;
using market_place.Models.Dto;
using market_place.Repository;

namespace market_place.Services;

public class SubCategoryService
{
    private readonly SubCategoryRepository _repository;
    private readonly DatabaseContext _context;
    private readonly ILogger _logger;
    
    public SubCategoryService(SubCategoryRepository repository, ILoggerFactory loggerFactory, DatabaseContext context)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _repository = repository;
        _context = context;
    }

    public async Task<Response<IEnumerable<Category>>> GetAllCategoryAsync()
    {
        var response = new Response<IEnumerable<Category>>();
        try
        {
            var categories = await _repository.GetAllAsync<Category>();
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = categories;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get category");
        }
        return response;
    }
    public async Task<Response<Category>> GetCategoryByIdAsync(int id)
    {
        var response = new Response<Category>();
        try
        {
            var category = await _repository.GetByIdAsync<Category>(id);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get category");
        }
        return response;
    }
    public async Task<Response<CategoryCreateRes>> InsertCategoryAsync(CategoryCreateReq req)
    {
        var response = new Response<CategoryCreateRes>();
        try
        {
            var category = new Category
            {
                Name = req.Name,
                IsDeleted = false
            };
            await _repository.InsertAsync(category);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new CategoryCreateRes()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to insert category");
        }
        return response;
    }
    public async Task<Response<CategoryUpdateRes>> UpdateCategoryAsync(CategoryUpdateReq req)
    {
        var response = new Response<CategoryUpdateRes>();
        try
        {
            var category = await _repository.GetByIdAsync<Category>(req.Id);
            var prevName = category.Name;
            category.Name = req.Name;
            await _repository.UpdateAsync(category);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new CategoryUpdateRes()
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
            _logger.LogError(e, "Failed to update category");
        }
        return response;
    }
    public async Task<Response<CategoryDeleteRes>> DeleteCategoryAsync(int id)
    {
        var response = new Response<CategoryDeleteRes>();
        try
        {
            var category = await _repository.GetByIdAsync<Category>(id);
            category.IsDeleted = true;
            var res = await _context.SaveChangesAsync() > 0;

            if (res)
            {
                response.Code = (int) Errors.Approved;
                response.Message = Errors.Approved.GetDescription();
                response.Payload = new CategoryDeleteRes
                {
                    Id = category.Id,
                };
            }
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