using AutoMapper;
using IdentityProj.Common.Constants;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Services.ApplicationUsers.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Services.ApplicationUsers.Command.Update;

public class UpdateCommandHandler : BaseService, IRequestHandler<UpdateCommand, UpdateUserDto>
{
    public UpdateCommandHandler(
        IMapper mapper,
        UserManagerRepository userManagerRepository) : base(mapper, userManagerRepository)
    {
    }

    public async Task<UpdateUserDto> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var user = await UserManagerRepository.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            return new UpdateUserDto { Errors = new[] { ErrorMessages.UserNotFound } };
        }

        user.Email = request.Email ?? user.Email;
        user.FullName = request.FullName ?? user.FullName;
        user.UserName = request.Username ?? user.UserName;
        user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;

        if (!string.IsNullOrEmpty(request.Password))
        {
            user.PasswordHash = UserManagerRepository.PasswordHasher.HashPassword(user, request.Password);
        }

        var result = await UserManagerRepository.UpdateAsync(user);

        return Mapper.Map<IdentityResult, UpdateUserDto>(result);
    }
}