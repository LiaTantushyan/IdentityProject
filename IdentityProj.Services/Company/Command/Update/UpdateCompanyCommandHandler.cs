using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Infrastructure.UnitOfWork;
using MediatR;

namespace IdentityProj.Services.Company.Command.Update;

public class UpdateCompanyCommandHandler : BaseService, IRequestHandler<UpdateCompanyCommand, ResultInfoDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCompanyCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo,
        IUnitOfWork unitOfWork) : base(mapper, userManagerRepo)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultInfoDto> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);
        if (company == null)
        {
            return new ResultInfoDto()
            {
                Errors = new[] { ErrorMessages.CompanyNotFound }
            };
        }

        if (!string.IsNullOrEmpty(request.Address))
        {
            company.Address = request.Address;
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            company.Name = request.Name;
        }

        if (request.Status != null)
        {
            company.Statuses = request.Status.Value;
        }

        _unitOfWork.CompanyRepository.Update(company);

        var result = await _unitOfWork.SaveAsync();
        
        return result;
    }
}