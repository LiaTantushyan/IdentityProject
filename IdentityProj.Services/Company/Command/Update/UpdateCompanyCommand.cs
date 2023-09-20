using IdentityProj.Common.Models;
using IdentityProj.Data.Enumerations;
using IdentityProj.Services.Company.DTOs;
using MediatR;

namespace IdentityProj.Services.Company.Command.Update;

public class UpdateCompanyCommand : IRequest<ResultInfoDto>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public Status? Status { get; set; }
}