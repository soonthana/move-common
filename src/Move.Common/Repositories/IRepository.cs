namespace Move.Common.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(object id);
    Task<T> GetAsync(object id);
    Task<bool> AddAsync(T obj);
    Task<bool> AddAsync(T obj, object id);
    Task<bool> UpdateAsync(T obj);
    Task<bool> UpdateAsync(T obj, object id);
    Task<bool> DeleteAsync(object id);
}