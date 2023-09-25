using market_place.Data;
using market_place.Models;
using market_place.Repository.Interface;

namespace market_place.Repository;

public class StoreRepository : BaseRepository<Store>, IStoreRepository
{

    public StoreRepository(DatabaseContext context) : base(context)
    {
    } 
}