using IdentityProj.Common.Models;

namespace IdentityProj.Services.ApplicationUsers.DTOs;

public class GetUserDto : ResultInfoDTO
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? TimeZone { get; set; }
}