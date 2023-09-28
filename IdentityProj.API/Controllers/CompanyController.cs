using MediatR;
using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Common.Enum;
using IdentityProj.Common.Models;
using IdentityProj.Models.Request.Company;
using IdentityProj.Models.Response.Generic;
using IdentityProj.Services.Company.Command.Create;
using IdentityProj.Services.Company.Command.Update;
using IdentityProj.Services.Company.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class CompanyController : BaseController
{
    public CompanyController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.CompanyAdmin))]
    public async Task<IActionResult> Create([FromBody] CompanyCreate model)
    {
        if (model.Status != null && !Enum.IsDefined(typeof(Statuses), model.Status))
        {
            return Json(new ResponseModel()
                { Succeeded = false, Errors = new[] { ErrorMessages.WrongIncomingParameter } });
        }

        var param = Mapper.Map<CompanyCreate, CreateCompanyCommand>(model);
        param.UserId = GetCurrentUserId();

        var result = await Mediator.Send(param);
        return Json(result);
    }

    [HttpGet]
    [Authorize(Roles = UserRole.Standart + UserRole.CompanyAdmin + UserRole.Supervisor)]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var result = await Mediator.Send(new GetCompanyByIdQuery
        {
            Id = id
        });

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] CompanyUpdate model)
    {
        if (model.Status != null && !Enum.IsDefined(typeof(Statuses), model.Status))
        {
            return Json(new ResponseModel()
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.WrongIncomingParameter }
            });
        }

        var param = Mapper.Map<CompanyUpdate, UpdateCompanyCommand>(model);
        param.UserId = GetCurrentUserId();

        var result = await Mediator.Send(param);

        return Json(Mapper.Map<ResultInfoDto, ResponseModel>(result));
    }
}