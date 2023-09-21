using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.Auth.Create;

public class CreateTokenCommand: IRequest<TokenDto>
{
    public string Username { get; set; }

    public string Password { get; set; }
}