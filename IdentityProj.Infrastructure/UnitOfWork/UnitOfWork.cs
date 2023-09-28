using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Common.Models;

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

    public IRefreshTokenRepository RefreshTokenRepository =>
        _refreshTokenRepository ??= new RefreshTokenRepository(_dbContext);

    public async Task<ResultInfoDto> SaveAsync()
    {
        var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return new ResultInfoDto()
            {
                Succeeded = true,
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();

            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _dbContext.Dispose();
        }

        _disposed = true;
    }
}