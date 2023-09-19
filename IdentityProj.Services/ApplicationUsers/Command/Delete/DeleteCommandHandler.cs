using AutoMapper;
using IdentityProj.Common.CustomExceptions;
using IdentityProj.Common.Models;
using IdentityProj.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Services.ApplicationUsers.Command.Delete;

public class DeleteCommandHandler : BaseService, IRequestHandler<DeleteCommand, ResultInfoDTO>
{
    public DeleteCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepository) : base(mapper, userManagerRepository)
    {
    }

    public async Task<ResultInfoDTO> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var user = await UserManagerRepository.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            return new ResultInfoDTO()
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.UserNotFound }
            };
        }

        var result = await UserManagerRepository.DeleteAsync(user);

        return Mapper.Map<IdentityResult, ResultInfoDTO>(result);
    }
}