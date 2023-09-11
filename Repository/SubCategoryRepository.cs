using market_place.Data;
using market_place.Repository.Interface;

namespace market_place.Repository;

public class SubCategoryRepository : BaseRepository, ISubCategoryRepository
{
    public SubCategoryRepository(DatabaseContext context) : base(context)
    {
    }
}