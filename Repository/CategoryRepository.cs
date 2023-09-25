using market_place.Data;
using market_place.Models;
using market_place.Repository.Interface;

namespace market_place.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    // private readonly DatabaseContext _context;

    public CategoryRepository(DatabaseContext context) : base(context)
    {
        // _context = context;
    }
}