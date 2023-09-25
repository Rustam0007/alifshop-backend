using market_place.Data;
using market_place.Models;
using market_place.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace market_place.Repository;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly DatabaseContext _context;

    public ProductRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetProductBySubCategoryId(int categoryId)
    {
        return await _context.Product.Where(p => p.SubCategoryId == categoryId).ToListAsync();
    }

    public async Task<List<Product>> GetProductByStoreId(int storeId)
    {
        return await _context.Store2Product.Where(p => p.StoreId == storeId).Select(s => s.Product).ToListAsync();
    }

    public async Task<List<Product>> GetProductByName(string name)
    {
        return await _context.Product.Where(p => p.Name.ToLower().Contains(name)).ToListAsync();
    }
}
