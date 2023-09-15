using MediatR;

namespace IdentityProj.Services.ApplicationUsers.Query.Get;

public class GetByIdQuery
{
    public int Id { get; set; }
}