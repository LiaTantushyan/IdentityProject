using IdentityProj.Services.Company.DTOs;
using MediatR;

namespace IdentityProj.Services.Company.Query;

public class GetCompanyByIdQuery: IRequest<CompanyDto>
{
    public int Id { get; set; }
}