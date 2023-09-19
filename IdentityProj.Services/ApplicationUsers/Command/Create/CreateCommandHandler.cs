using AutoMapper;
using MediatR;
using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Services.ApplicationUsers.DTOs;
using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Services.ApplicationUsers.Command.Create;

public class CreateCommandHandler : BaseService, IRequestHandler<CreateCommand, CreateUserDTO>
{
    public CreateCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo): base(mapper, userManagerRepo)
    {
    }

    public async Task<CreateUserDTO> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<ApplicationUser>(request);

        var result = await UserManagerRepository.CreateAsync(user, user.PasswordHash);
    
        var usr = Mapper.Map<ApplicationUser, CreateUserDTO>(user);

        return Mapper.Map(result, usr);
    }
}