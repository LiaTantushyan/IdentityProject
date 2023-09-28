using IdentityProj.Services.ApplicationUsers.DTOs;
using MediatR;

namespace IdentityProj.Services.ApplicationUsers.Command.Create;

public class CreateCommand: IRequest<CreateUserDto>
{
    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? TimeZone { get; set; }

    public string? Password { get; set; }
}