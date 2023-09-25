using System.Runtime.CompilerServices;
using market_place.Extensions;
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

    public async IAsyncEnumerable<ProductInfo> GetAllProductAsync([EnumeratorCancellation] CancellationToken token = default)
    {
        await foreach (var product in _repository.GetAllAsync())
        {
            token.ThrowIfCancellationRequested();
            yield return product.ToProductInfo();
        }
    }
    public async Task<IEnumerable<Product>> GetAllProductBySubCategoryId(int categoryId)
    {
       var products = await _repository.GetProductBySubCategoryId(categoryId);
       return products;

    }
    public async Task<IEnumerable<Product>> GetAllProductByStoreId(int storeId)
    {
       var products = await _repository.GetProductByStoreId(storeId);
       return products;
    }
    public async Task<IEnumerable<Product>> GetAllProductByName(string productName)
    {
        var products = await _repository.GetProductByName(productName);
        return products;
    }
    public async Task<ProductInfo> GetProductByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product.ToProductInfo();
    }
    public async Task<ProductCreateRes> InsertProductAsync(ProductCreateReq req, CancellationToken token)
    {
        var product = req.ToProduct();
        
        await _repository.InsertAsync(product, token);

        return new ()
        {
            Id = product.Id
        };
    }
    public async Task<ProductUpdateRes> UpdateProductAsync(ProductUpdateReq req, CancellationToken token)
    {
        var product = await _repository.GetByIdAsync(req.Id, token);
        product.Name = req.Name;
        product.Description = req.Description;
        product.Colors = req.Colors;
        product.Price = req.Price;
        product.SubCategoryId = req.SubCategoryId;
        
       return new ()
        {
            Id = product.Id
        };
    }
    public async Task<ProductDeleteRes> DeleteProductAsync(int id, CancellationToken token)
    {
        var product = await _repository.GetByIdAsync(id, token);
        product.IsDeleted = true;
        await _repository.SaveChangesAsync(token);
        return new()
        {
            Id = product.Id,
        };
    }
}