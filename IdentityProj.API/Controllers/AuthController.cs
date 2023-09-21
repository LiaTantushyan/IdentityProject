using AutoMapper;
using IdentityProj.Models.Request.Auth;
using IdentityProj.Services.Auth.Create;
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
        var param = Mapper.Map<LoginRequest, CreateTokenCommand>(model);

        var result = await Mediator.Send(param);

        return Ok(result);
    }
}