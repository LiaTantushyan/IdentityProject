using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Infrastructure.UnitOfWork;
using MediatR;

namespace IdentityProj.Services.Common.Auth.RefreshToken;

public class RefreshTokenCommandHandler : BaseService, IRequestHandler<RefreshTokenCommand, TokenDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo,
        IUnitOfWork unitOfWork,
        IAuthService authService) : base(mapper, userManagerRepo)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<TokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = new TokenDto();
        
        var validatedToken = _authService.GetPrincipalFromToken(request.AccessToken!);

        if (validatedToken == null)
        {
            return new TokenDto {Errors = new[] {ErrorMessages.InvalidToken}};
        }

        var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

        var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(expiryDateUnix);

        if (expiryDateTimeUtc > DateTime.UtcNow)
        {
            return new TokenDto {Errors = new[] {ErrorMessages.TokenNotExpired}};
        }
        
        var refreshToken = await _unitOfWork.RefreshTokenRepository.GetByTokenValueAsync(request.RefreshToken);

        if (refreshToken == null)
        {
            result.Succeeded = false;
            result.Errors = new[] { ErrorMessages.RefreshTokenNotFound };

            return result;
        }

        if (refreshToken.ExpiryDate < DateTime.UtcNow)
        {
            result.Succeeded = false;
            result.Errors = new[] { ErrorMessages.InvalidToken };

            return result;
        }

        if (refreshToken.Used)
        {
            result.Succeeded = false;
            result.Errors = new[] { ErrorMessages.UsedRefreshedToken };

            return result;
        }

        refreshToken.Used = true;
        refreshToken.ExpiryDate = DateTime.UtcNow;

        _unitOfWork.RefreshTokenRepository.Update(refreshToken);
        await _unitOfWork.SaveAsync();

        var user = await UserManagerRepository.FindByIdAsync(refreshToken.UserId.ToString());

        return await _authService.GenerateTokenAsync(user);
    }
}