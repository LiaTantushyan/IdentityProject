using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityProj.Common.Models;

namespace IdentityProj.Infrastructure.Interfaces;

public interface ITokenService
{
    Task<TokenDto> GenerateTokenAsync(List<Claim> authClaims);
}