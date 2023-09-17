using market_place.Data;
using market_place.Models;
using market_place.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace market_place.Repository;

public class SubCategoryRepository : BaseRepository, ISubCategoryRepository
{
    private readonly DatabaseContext _context;

    public SubCategoryRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<SubCategory>> GetSubCategoryByCategoryId(int categoryId)
    {
        return await _context.SubCategory.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
}