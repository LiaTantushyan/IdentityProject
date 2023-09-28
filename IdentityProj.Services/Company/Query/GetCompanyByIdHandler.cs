using AutoMapper;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Infrastructure.UnitOfWork;
using IdentityProj.Services.Company.DTOs;
using MediatR;

namespace IdentityProj.Services.Company.Query;

public class GetCompanyByIdHandler : BaseService, IRequestHandler<GetCompanyByIdQuery, CompanyDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCompanyByIdHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo,
        IUnitOfWork unitOfWork)
        : base(mapper, userManagerRepo)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _unitOfWork.CompanyRepository.GetCompanyDataById(request.Id);

        return Mapper.Map<Data.Entity.Company?, CompanyDto>(company);
    }
}