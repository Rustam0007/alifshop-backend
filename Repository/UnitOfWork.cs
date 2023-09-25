using market_place.Data;

namespace market_place.Repository;

public abstract class UnitOfWork
{
    private readonly DatabaseContext _context;

    protected UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }
    
    public abstract Task<int> SaveChangesAsync(CancellationToken token = default);
}