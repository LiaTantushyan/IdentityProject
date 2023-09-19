using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;

namespace IdentityProj.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    public ICompanyRepository CompanyRepository { get; }

    Task<ResultInfoDTO> SaveAsync();
}