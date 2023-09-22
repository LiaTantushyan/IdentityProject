using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;

namespace IdentityProj.Infrastructure.UnitOfWork;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private ICompanyRepository? _companyRepository;
    private IRefreshTokenRepository? _refreshTokenRepository;
    private readonly ApplicationDbContext _dbContext;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_dbContext);
    public IRefreshTokenRepository RefreshTokenRepository => _refreshTokenRepository ??= new RefreshTokenRepository(_dbContext);

    public async Task<ResultInfoDto> SaveAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw;
        }

        return new ResultInfoDto()
        {
            Succeeded = true,
        };
    }

    public void Dispose()
    {
        //Dispose(true);
        //GC.SuppressFinalize(this);
    }
}