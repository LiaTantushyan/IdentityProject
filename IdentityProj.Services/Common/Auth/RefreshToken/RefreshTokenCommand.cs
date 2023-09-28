using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.Common.Auth.RefreshToken;

public class RefreshTokenCommand : IRequest<TokenDto>
{
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}