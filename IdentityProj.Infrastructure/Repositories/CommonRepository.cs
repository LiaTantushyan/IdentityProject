using IdentityProj.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdentityProj.Infrastructure.Repositories;

public class CommonRepository<T> : ICommonRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public CommonRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return (await _dbContext.Set<T>().FindAsync(id))!;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task Create(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}