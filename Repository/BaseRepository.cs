using market_place.Data;
using market_place.Models;
using market_place.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace market_place.Repository;

public class BaseRepository<T> : UnitOfWork, IBaseRepository<T> where T : BaseEntity
{
    private readonly DatabaseContext _context;

    public BaseRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        return await _context.SaveChangesAsync(token);
    }

    public IAsyncEnumerable<T> GetAllAsync()
    {
        return _context.Set<T>().AsAsyncEnumerable();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken token = default)
    {
        return await _context.Set<T>().FindAsync(id, token) 
               ?? throw new InvalidOperationException($"Entity with {id} not found!");
    }

    public async Task<int> InsertAsync(T entity, CancellationToken token = default)
    {
        var res = await _context.Set<T>().AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
        return res.Entity.Id;
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken token = default)
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync(token) > 0;
    }
}
    