using AutoMapper;
using IdentityProj.Models.Request.Company;
using IdentityProj.Services.Company.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.Controllers;

[Route("[controller]/[action]")]
public class CompanyController : BaseController
{
    public CompanyController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CompanyCreate model)
    {
        var param = Mapper.Map<CompanyCreate, CreateCompanyCommand>(model);

        var result = await Mediator.Send(model);
        return Json("");
    }
}