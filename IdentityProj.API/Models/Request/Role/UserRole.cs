using System.ComponentModel.DataAnnotations;
using IdentityProj.Common.Enum;

namespace IdentityProj.Models.Request.Role;

public class UserRole
{
    [Required] 
    public int UserId { get; set; }

    [Required] 
    public UserRoles Role { get; set; }
}