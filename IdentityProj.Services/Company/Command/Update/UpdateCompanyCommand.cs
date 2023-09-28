using IdentityProj.Common.Enum;
using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.Company.Command.Update;

public class UpdateCompanyCommand : IRequest<ResultInfoDto>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public Statuses? Status { get; set; }
    
    public int? UserId { get; set; }
}