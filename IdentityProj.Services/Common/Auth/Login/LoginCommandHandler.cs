using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;
using MediatR;

namespace IdentityProj.Services.Common.Auth.Login;

public class LoginCommandHandler : BaseService, IRequestHandler<LoginCommand, TokenDto>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo,
        IAuthService authService) : base(mapper, userManagerRepo)
    {
        _authService = authService;
    }

    public async Task<TokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
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

        return await _authService.GenerateTokenAsync(user);
    }
}