using IdentityProj.Services.ApplicationUsers.DTOs;
using MediatR;

namespace IdentityProj.Services.ApplicationUsers.Query.Get;

public class GetByIdQuery : IRequest<GetUserDto>
{
    public int Id { get; set; }
}