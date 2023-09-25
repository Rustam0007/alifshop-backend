using market_place.Models;

namespace market_place.Repository.Interface;

public interface IBaseRepository<T> where T : BaseEntity
{
    IAsyncEnumerable<T> GetAllAsync();
    Task<T?> GetByIdAsync(int id, CancellationToken token = default);
    Task<int> InsertAsync(T entity, CancellationToken token = default);
    Task<bool> UpdateAsync(T entity, CancellationToken token = default);
}