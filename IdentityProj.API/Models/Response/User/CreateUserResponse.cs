using IdentityProj.Models.Response.Generic;

namespace IdentityProj.Models.Response.User;

public class CreateUserResponse: ResponseModel
{
    public int Id { get; set; }
    
    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? TimeZone { get; set; }
}