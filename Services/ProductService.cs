using market_place.Enums;
using market_place.Models;
using market_place.Models.Dto;
using market_place.Repository;

namespace market_place.Services;
public class ProductService
{
    private readonly ProductRepository _repository;
    private readonly ILogger _logger;
    
    public ProductService(ProductRepository repository, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(GetType().Name);
        _repository = repository;
    }

    public async Task<Response<IEnumerable<Product>>> GetAllProductAsync()
    {
        var response = new Response<IEnumerable<Product>>();
        try
        {
            var products = await _repository.GetAllAsync<Product>();
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = products;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Product");
        }
        return response;
    }
    public async Task<Response<IEnumerable<Product>>> GetAllProductBySubCategoryId(int categoryId)
    {
        var response = new Response<IEnumerable<Product>>();
        try
        {
            var products = await _repository.GetProductBySubCategoryId(categoryId);
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = products;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Product");
        }
        return response;
    }
    public async Task<Response<IEnumerable<Product>>> GetAllProductByStoreId(int storeId)
    {
        var response = new Response<IEnumerable<Product>>();
        try
        {
            var products = await _repository.GetProductByStoreId(storeId);
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = products;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Product");
        }
        return response;
    }
    public async Task<Response<IEnumerable<Product>>> GetAllProductByName(string productName)
    {
        var response = new Response<IEnumerable<Product>>();
        try
        {
            var products = await _repository.GetProductByName(productName);
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = products;
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Product");
        }
        return response;
    }
    public async Task<Response<Product>> GetProductByIdAsync(int id)
    {
        var response = new Response<Product>();
        try
        {
            var product = await _repository.GetByIdAsync<Product>(id);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new Product
            {
                Id = product.Id,
                Name = product.Name,
                IsDeleted = product.IsDeleted,
                Description = product.Description,
                Colors = product.Colors,
                Price = product.Price,
                SubCategoryId = product.SubCategoryId
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to get Product");
        }
        return response;
    }
    public async Task<Response<ProductCreateRes>> InsertProductAsync(ProductCreateReq req)
    {
        var response = new Response<ProductCreateRes>();
        try
        {
            var product = new Product
            {
                Name = req.Name,
                Description = req.Description,
                Colors = req.Colors,
                Price = req.Price,
                SubCategoryId = req.SubCategoryId,
                IsDeleted = false
            };
            
            var productId = await _repository.InsertAsync(product);
            await _repository.InsertAsync(new Store2Product
            {
                StoreId = req.StoreId,
                ProductId = productId
            });
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new ProductCreateRes
            {
                Id = product.Id
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to insert Product");
        }
        return response;
    }
    public async Task<Response<ProductUpdateRes>> UpdateProductAsync(ProductUpdateReq req)
    {
        var response = new Response<ProductUpdateRes>();
        try
        {
            var product = await _repository.GetByIdAsync<Product>(req.Id);
            product.Name = req.Name;
            product.Description = req.Description;
            product.Colors = req.Colors;
            product.Price = req.Price;
            product.SubCategoryId = req.CategoryId;
            
            await _repository.UpdateAsync(product);

            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new ProductUpdateRes
            {
                Id = product.Id
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to update Product");
        }
        return response;
    }
    public async Task<Response<ProductDeleteRes>> DeleteProductAsync(int id)
    {
        var response = new Response<ProductDeleteRes>();
        try
        {
            var product = await _repository.GetByIdAsync<Product>(id);
            product.IsDeleted = true;
            await _repository.SaveChangesAsync();
            
            response.Code = (int) Errors.Approved;
            response.Message = Errors.Approved.GetDescription();
            response.Payload = new ProductDeleteRes
            {
                Id = product.Id,
            };
        }
        catch (Exception e)
        {
            response.Code = (int) Errors.InternalError;
            response.Message = Errors.InternalError.GetDescription();
            _logger.LogError(e, "Failed to delete Product");
        }
        return response;
    }
}