using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IdentityProj.Common.Configuration;
using IdentityProj.Common.Models;
using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.UnitOfWork;
using Microsoft.IdentityModel.Tokens;

namespace IdentityProj.Infrastructure.Repositories;

public class AuthService : IAuthService
{
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        JwtSettings jwtSettings,
        IUnitOfWork unitOfWork,
        TokenValidationParameters tokenValidationParameters)
    {
        _unitOfWork = unitOfWork;
        _jwtSettings = jwtSettings;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<TokenDto> GenerateTokenAsync(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var authSigningKey = Encoding.ASCII.GetBytes(_jwtSettings.Secret!);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("id", user.Id.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_jwtSettings.AccessTokenLifeTime),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(authSigningKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var accessToken = tokenHandler.CreateToken(tokenDescriptor);

        var refreshToken = new RefreshToken
        {
            Value = Convert.ToBase64String(new HMACSHA256().Key),
            JwtId = accessToken.Id,
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.Add(_jwtSettings.RefreshTokenLifeTime)
        };

        await _unitOfWork.RefreshTokenRepository.Create(refreshToken);
        await _unitOfWork.SaveAsync();

        return new TokenDto()
        {
            Succeeded = true,
            AccessToken = tokenHandler.WriteToken(accessToken),
            RefreshToken = refreshToken.Value
        };
    }

    public ClaimsPrincipal? GetPrincipalFromToken(string? token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

            return !IsValidJwtWithSecurityAlgorithm(validatedToken) ? null : principal;
        }
        catch
        {
            return null;
        }
    }

    private static bool IsValidJwtWithSecurityAlgorithm(SecurityToken validatedToken)
    {
        return validatedToken is JwtSecurityToken jwtSecurityToken &&
               jwtSecurityToken.Header.Alg.Equals(
                   SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
    }
}