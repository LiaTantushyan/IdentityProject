using IdentityProj.Data.Entity;

namespace IdentityProj.Infrastructure.Interfaces;

public interface IRefreshTokenRepository: ICommonRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenValueAsync(string value);
}