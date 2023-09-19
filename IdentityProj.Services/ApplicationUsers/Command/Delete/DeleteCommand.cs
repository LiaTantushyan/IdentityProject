using IdentityProj.Common.Models;
using MediatR;

namespace IdentityProj.Services.ApplicationUsers.Command.Delete;

public class DeleteCommand: IRequest<ResultInfoDTO>
{
    public int Id { get; set; }
}