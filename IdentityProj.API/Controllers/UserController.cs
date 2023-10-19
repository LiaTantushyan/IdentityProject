using MediatR;
using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Common.Enum;
using IdentityProj.Common.Interfaces.EmailSender;
using IdentityProj.Common.Models;
using IdentityProj.Common.Models.Email;
using IdentityProj.Models.Request.Role;
using IdentityProj.Models.Request.User;
using IdentityProj.Models.Response;
using IdentityProj.Models.Response.Generic;
using IdentityProj.Models.Response.User;
using IdentityProj.Services.ApplicationUsers.Command.Create;
using IdentityProj.Services.ApplicationUsers.Command.Delete;
using IdentityProj.Services.ApplicationUsers.Command.Update;
using IdentityProj.Services.ApplicationUsers.DTOs;
using IdentityProj.Services.ApplicationUsers.Query.Get;
using IdentityProj.Services.Role.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserRole = IdentityProj.Models.Request.Role.UserRole;

namespace IdentityProj.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : BaseController
{
    private readonly IEmailSenderApi _emailSenderApi;

    public UserController(IMapper mapper,
        IMediator mediator,
        IEmailSenderApi emailSenderApi)
        : base(mapper, mediator)
    {
        _emailSenderApi = emailSenderApi;
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

        if (result.Succeeded)
        {
            await _emailSenderApi.SendEmailAsync(new EmailModel
            {
                Content = "Hello world",
                ReceiverId = 1,
                Receiver = "tantushyanlia9@gmail.com",
                Subject = "Email sender test"
            });
        }

        return Json(Mapper.Map<CreateUserDto, CreateUserResponse>(result));
    }

    [HttpDelete]
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

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.Supervisor))]
    public async Task<ResponseModel> AddRole(UserRole model)
    {
        if (!Enum.IsDefined(typeof(UserRoles), model.Role))
        {
            return new ResponseModel()
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.WrongIncomingParameter }
            };
        }

        var param = Mapper.Map<UserRole, AddRoleCommand>(model);

        var result = await Mediator.Send(param);

        return Mapper.Map<ResultInfoDto, ResponseModel>(result);
    }
}