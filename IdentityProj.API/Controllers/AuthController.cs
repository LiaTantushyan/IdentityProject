using System.Security.Claims;
using AutoMapper;
using IdentityProj.Data.Entity;
using IdentityProj.Models.Request.Auth;
using IdentityProj.Services.Common.Auth.Login;
using IdentityProj.Services.Common.Auth.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.Controllers;

[Route("[controller]/[action]")]
public class AuthController : BaseController
{
    public AuthController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        var param = Mapper.Map<LoginRequest, LoginCommand>(model);

        var result = await Mediator.Send(param);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest model)
    {
        var param = Mapper.Map<RefreshTokenRequest, RefreshTokenCommand>(model);

        var result = await Mediator.Send(param);

        return Ok(result);
    }
}