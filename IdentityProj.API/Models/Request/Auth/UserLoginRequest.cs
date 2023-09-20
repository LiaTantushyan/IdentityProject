using System.ComponentModel.DataAnnotations;

namespace IdentityProj.Models.Request.Auth;

public class UserLoginRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}