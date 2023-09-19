using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Interfaces;

namespace IdentityProj.Infrastructure.Repositories;

public class CompanyRepository: CommonRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task AddEmployeesAsync(List<int> ids)
    {
        throw new NotImplementedException();
    }
}