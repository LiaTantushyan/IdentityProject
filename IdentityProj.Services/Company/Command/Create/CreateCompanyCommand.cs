using IdentityProj.Common.Enum;
using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.Company.Command.Create;

public class CreateCompanyCommand : IRequest<ResultInfoDto>
{
    public string? Name { get; set; }

    public string? Address { get; set; }

    public Statuses? Status { get; set; }
    
    public int? UserId { get; set; }
}