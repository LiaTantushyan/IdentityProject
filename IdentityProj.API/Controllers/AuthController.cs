using AutoMapper;
using IdentityProj.Models.Request.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.Controllers;

public class AuthController: BaseController
{
    public AuthController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
    {
        return Ok();
    }
}