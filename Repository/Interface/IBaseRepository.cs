namespace market_place.Repository.Interface;

public interface IBaseRepository
{
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<T> GetByIdAsync<T>(int id) where T : class;
    Task<bool> InsertAsync<T>(T entity) where T : class;
    Task<bool> UpdateAsync<T>(T entity) where T : class;
}