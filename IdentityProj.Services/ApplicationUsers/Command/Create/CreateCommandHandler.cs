using AutoMapper;
using MediatR;
using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Services.ApplicationUsers.DTOs;

namespace IdentityProj.Services.ApplicationUsers.Command.Create;

public class CreateCommandHandler : BaseService, IRequestHandler<CreateCommand, CreateUserDto>
{
    public CreateCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepo) : base(mapper, userManagerRepo)
    {
    }

    public async Task<CreateUserDto> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<ApplicationUser>(request);
        var result = await UserManagerRepository.CreateAsync(user, user.PasswordHash);
        
        var userDto = Mapper.Map<ApplicationUser, CreateUserDto>(user);
        return Mapper.Map(result, userDto);
    }
}