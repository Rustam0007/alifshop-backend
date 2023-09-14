using market_place.Data;
using market_place.Repository.Interface;

namespace market_place.Repository;

public class StoreRepository : BaseRepository, IStoreRepository
{

    public StoreRepository(DatabaseContext context) : base(context)
    {
    } 
}