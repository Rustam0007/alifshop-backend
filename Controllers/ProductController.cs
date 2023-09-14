using market_place.Models;
using market_place.Models.Dto;
using market_place.Services;
using Microsoft.AspNetCore.Mvc;
using Product = market_place.Models.Product;

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
    public async Task<Response<IEnumerable<Product>>> GetAllProduct()
    {
        return await _productService.GetAllProductAsync();
    }
    [HttpGet("by-category/{categoryId:int}")]
    public async Task<Response<IEnumerable<Product>>> GetProductByCategoryId(int categoryId)
    {
        return await _productService.GetAllProductByCategoryId(categoryId);
    }
    [HttpGet("by-store/{storeId:int}")]
    public async Task<Response<IEnumerable<Product>>> GetProductByStoreId(int storeId)
    {
        return await _productService.GetAllProductByStoreId(storeId);
    }
    [HttpGet("by-name/{name}")]
    public async Task<Response<IEnumerable<Product>>> GetProductByName(string name)
    {
        return await _productService.GetAllProductByName(name);
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Product>> GetProductById(int id)
    {
        return await _productService.GetProductByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<ProductCreateRes>> InsertProduct([FromBody] ProductCreateReq req)
    {
        return await _productService.InsertProductAsync(req);
    }
    [HttpPatch]
    public async Task<Response<ProductUpdateRes>> InsertProduct([FromBody] ProductUpdateReq req)
    {
        return await _productService.UpdateProductAsync(req);
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<ProductDeleteRes>> DeleteProduct(int id)
    {
        return await _productService.DeleteProductAsync(id);
    }
}