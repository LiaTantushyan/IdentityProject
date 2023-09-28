using System.Security.Claims;
using IdentityProj.Common.Models;
using IdentityProj.Data.Entity;

namespace IdentityProj.Infrastructure.Interfaces;

public interface IAuthService
{
    Task<TokenDto> GenerateTokenAsync(ApplicationUser user);
    
    ClaimsPrincipal? GetPrincipalFromToken(string? token);
}