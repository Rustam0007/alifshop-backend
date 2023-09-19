﻿using market_place.Data;
using market_place.Models;
using market_place.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace market_place.Repository;

public class BaseRepository : UnitOfWork, IBaseRepository
{
    private readonly DatabaseContext _context;

    public BaseRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync<T>(T entity) where T : BaseEntity
    {
        var res = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return res.Entity.Id;
    }

    public async Task<bool> UpdateAsync<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
    