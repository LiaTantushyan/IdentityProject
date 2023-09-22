using IdentityProj.Common.Models;
using IdentityProj.Data.Enumerations;
using MediatR;

namespace IdentityProj.Services.Company.Command.Create;

public class CreateCompanyCommand : IRequest<ResultInfoDto>
{
    public string? Name { get; set; }

    public string? Address { get; set; }

    public Status? Status { get; set; }
    
    public int? UserId { get; set; }
}