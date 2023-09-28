using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Common.Enum;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Repositories;
using MediatR;

namespace IdentityProj.Services.Role.Command;

public class AddRoleCommandHandler : BaseService, IRequestHandler<AddRoleCommand, ResultInfoDto>
{
    public AddRoleCommandHandler(IMapper mapper, UserManagerRepository userManagerRepo)
        : base(mapper, userManagerRepo)
    {
    }

    public async Task<ResultInfoDto> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultInfoDto();

        if (!Enum.IsDefined(typeof(UserRoles), request.Role))
        {
            result.Errors = new[] { ErrorMessages.WrongIncomingParameter };
            return result;
        }

        var user = await UserManagerRepository.FindByIdAsync(request.UserId.ToString());

        if (user == null)
        {
            result.Errors = new[] { ErrorMessages.WrongIncomingParameter };
            return result;
        }

        if (!await UserManagerRepository.IsInRoleAsync(user, Enum.GetName(request.Role)))
        {
            var identityResult = await UserManagerRepository.AddToRoleAsync(user, Enum.GetName(request.Role));

            Mapper.Map(identityResult, result);
        }

        return result;
    }
}