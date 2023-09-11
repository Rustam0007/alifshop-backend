namespace market_place.Repository.Interface;

public interface ICategoryRepository : IBaseRepository
{
    Task<bool> DeleteCategoryAsync<T>(T entity) where T : class;
}