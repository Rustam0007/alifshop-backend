using market_place.Data;
using market_place.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace market_place.Repository;

public class BaseRepository : IBaseRepository
{
    private readonly DatabaseContext _context;

    public BaseRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<bool> InsertAsync<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
    