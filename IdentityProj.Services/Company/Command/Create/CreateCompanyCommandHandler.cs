using AutoMapper;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Infrastructure.UnitOfWork;
using IdentityProj.Services.Company.DTOs;
using MediatR;

namespace IdentityProj.Services.Company.Command.Create;

public class CreateCompanyCommandHandler : BaseService, IRequestHandler<CreateCompanyCommand, ResultInfoDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    protected CreateCompanyCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo,
        IUnitOfWork unitOfWork)
        : base(mapper, userManagerRepo)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultInfoDTO> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = Mapper.Map<CreateCompanyCommand, Data.Entity.Company>(request);

        await _unitOfWork.CompanyRepository.Create(company);

        var result = await _unitOfWork.SaveAsync();

        return result;
    }
}