namespace IdentityProj.Infrastructure.Interfaces;

public interface ICommonRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task Create(T model);

    void Delete(T entity);

    void Update(T entity);
}