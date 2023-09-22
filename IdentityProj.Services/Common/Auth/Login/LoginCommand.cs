using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.Common.Auth.Login;

public class LoginCommand: IRequest<TokenDto>
{ 
    public string Username { get; set; }

    public string Password { get; set; }
}