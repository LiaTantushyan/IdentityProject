using IdentityProj.Data.Entity;

namespace IdentityProj.Infrastructure.Interfaces;

public interface ICompanyRepository: ICommonRepository<Company>
{
    Task<Company?> GetCompanyDataById(int id);
}