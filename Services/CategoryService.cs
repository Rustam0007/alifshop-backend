﻿using market_place.Enums;
using market_place.Models;
using market_place.Models.Dto;
using market_place.Repository;

namespace market_place.Services;
public class CategoryService
{
    private readonly CategoryRepository _repository;
    private readonly ILogger _logger;
    
    public CategoryService(CategoryRepository repository, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _repository = repository;
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
                CategoryName = category.CategoryName
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
                CategoryName = req.Name
            };
            await _repository.InsertAsync(category);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new CategoryCreateRes()
            {
                Id = category.Id,
                Name = category.CategoryName
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
}