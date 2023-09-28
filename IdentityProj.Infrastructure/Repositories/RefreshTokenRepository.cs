using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdentityProj.Infrastructure.Repositories;

public class RefreshTokenRepository : CommonRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<RefreshToken?> GetByTokenValueAsync(string value)
    {
        return await DbContext.RefreshTokens.FirstOrDefaultAsync(i => i.Value == value);
    }
}