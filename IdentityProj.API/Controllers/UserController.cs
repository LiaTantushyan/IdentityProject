using MediatR;
using AutoMapper;
using IdentityProj.Infrastructure;
using IdentityProj.Infrastructure.UnitOfWork;
using IdentityProj.Models.Request.User;
using IdentityProj.Models.Response.User;
using IdentityProj.Services.ApplicationUsers.Command.Create;
using IdentityProj.Services.ApplicationUsers.Command.Delete;
using IdentityProj.Services.ApplicationUsers.Command.Update;
using IdentityProj.Services.ApplicationUsers.DTOs;
using IdentityProj.Services.ApplicationUsers.Query.Get;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.Controllers;

[Route("[controller]/[action]")]
public class UserController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UserController(IMapper mapper, IMediator mediator, ApplicationDbContext db, IUnitOfWork unitOfWork) : base(mapper, mediator)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var result = await Mediator.Send(new GetByIdQuery
        {
            Id = id
        });

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateRequest model)
    {
        var comm = Mapper.Map<UserCreateRequest, CreateCommand>(model);
        var result = await Mediator.Send(comm);

        return Json(Mapper.Map<CreateUserDTO, CreateUserResponse>(result));
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var result = await Mediator.Send(new DeleteCommand
        {
            Id = id
        });

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UserUpdate model)
    {
        var comm = Mapper.Map<UserUpdate, UpdateCommand>(model);
        var result = await Mediator.Send(comm);

        return Json(Mapper.Map<UpdateUserDto, UpdateUserResponse>(result));
    }
}