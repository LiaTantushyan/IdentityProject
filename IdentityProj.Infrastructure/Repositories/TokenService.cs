using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IdentityProj.Common.Configuration;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace IdentityProj.Infrastructure.Repositories;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public TokenService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public async Task<TokenDto> GenerateTokenAsync(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret!));
        int.TryParse(_jwtSettings.AccessTokenLifeTime, out int accessTokenValidityInMinutes);
        int.TryParse(_jwtSettings.RefreshTokenLifeTime, out int refreshTokenValidityInMinutes);

        var accessToken = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(accessTokenValidityInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        var refreshToken = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(refreshTokenValidityInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new TokenDto()
        {
            Succeeded = true,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
        };
    }
}