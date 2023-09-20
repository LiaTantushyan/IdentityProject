using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdentityProj.Infrastructure.Repositories;

public class CompanyRepository : CommonRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Company?> GetCompanyDataById(int id)
    {
        return await DbContext.Companies
            .Include(i => i!.Employees)
            .FirstOrDefaultAsync(i => i!.Id == id); ;
    }
}