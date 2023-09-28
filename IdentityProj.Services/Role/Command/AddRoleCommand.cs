using IdentityProj.Common.Enum;
using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.Role.Command;

public class AddRoleCommand : IRequest<ResultInfoDto>
{
    public int UserId { get; set; }

    public UserRoles Role { get; set; }
}