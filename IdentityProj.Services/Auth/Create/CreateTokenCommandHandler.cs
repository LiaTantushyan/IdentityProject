using System.Security.Claims;
using AutoMapper;
using IdentityProj.Common.CustomExceptions;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;
using MediatR;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace IdentityProj.Services.Auth.Create;

public class CreateTokenCommandHandler : BaseService, IRequestHandler<CreateTokenCommand, TokenDto>
{
    private readonly ITokenService _tokenService;

    public CreateTokenCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo,
        ITokenService tokenService) : base(mapper,
        userManagerRepo)
    {
        _tokenService = tokenService;
    }

    public async Task<TokenDto> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await UserManagerRepository.FindByEmailAsync(request.Username);

        if (user == null)
        {
            return new TokenDto()
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.UserNotFound }
            };
        }

        var isCorrectPassword = await UserManagerRepository.CheckPasswordAsync(user, request.Password);
        if (!isCorrectPassword)
        {
            return new TokenDto()
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.WrongPassword }
            };
        }

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var accessToken = await _tokenService.GenerateTokenAsync(authClaims);

        return await _tokenService.GenerateTokenAsync(authClaims);
    }
}