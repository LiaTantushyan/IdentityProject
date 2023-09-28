using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Services.ApplicationUsers.DTOs;
using MediatR;

namespace IdentityProj.Services.ApplicationUsers.Query.Get;

public class GetByIdQueryHandler : BaseService, IRequestHandler<GetByIdQuery, GetUserDto>
{
    public GetByIdQueryHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo) : base(mapper, userManagerRepo)
    {
    }

    public async Task<GetUserDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await UserManagerRepository.FindByIdAsync(request.Id.ToString());

        if (user == null)
        {
            return new GetUserDto
            {
                Succeeded = false,
                Errors = new[] { ErrorMessages.UserNotFound }
            };
        }

        return Mapper.Map<ApplicationUser, GetUserDto>(user);
    }
}