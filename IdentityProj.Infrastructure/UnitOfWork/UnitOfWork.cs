using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;

namespace IdentityProj.Infrastructure.UnitOfWork;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private ICompanyRepository? _companyRepository;
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_dbContext);

    public async Task<ResultInfoDTO> SaveAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return new ResultInfoDTO()
            {
                Succeeded = false,
                Errors = new[] { e.ToString() }
            };
        }

        return new ResultInfoDTO()
        {
            Succeeded = true,
        };
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}