using market_place.Models;
using market_place.Models.Dto;
using market_place.Services;
using Microsoft.AspNetCore.Mvc;

namespace market_place.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IAsyncEnumerable<ProductInfo> GetAllProduct(CancellationToken token)
    {
        return _productService.GetAllProductAsync(token);
    }
    
    [HttpGet("by-subCategory/{subCategoryId:int}")]
    public Task<IEnumerable<Product>> GetProductBySubCategoryId(int subCategoryId)
    {
        return _productService.GetAllProductBySubCategoryId(subCategoryId);
    }
    
    [HttpGet("by-store/{storeId:int}")]
    public Task<IEnumerable<Product>> GetProductByStoreId(int storeId)
    {
        return _productService.GetAllProductByStoreId(storeId);
    }
    
    [HttpGet("by-name/{name}")]
    public Task<IEnumerable<Product>> GetProductByName(string name)
    {
        return _productService.GetAllProductByName(name);
    }
    
    [HttpGet("{id:int}")]
    public Task<ProductInfo> GetProductById(int id)
    {
        return _productService.GetProductByIdAsync(id);
    }
    
    [HttpPost]
    public Task<ProductCreateRes> InsertProduct([FromBody] ProductCreateReq req, CancellationToken token)
    {
        return _productService.InsertProductAsync(req, token);
    }
    
    [HttpPatch]
    public Task<ProductUpdateRes> InsertProduct([FromBody] ProductUpdateReq req, CancellationToken token)
    {
        return _productService.UpdateProductAsync(req, token);
    }
    
    [HttpDelete("{id:int}")]
    public Task<ProductDeleteRes> DeleteProduct(int id, CancellationToken token)
    {
        return _productService.DeleteProductAsync(id, token);
    }
}