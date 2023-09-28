using System.ComponentModel.DataAnnotations;

namespace IdentityProj.Models.Request.Auth;

public class RefreshTokenRequest
{
    [Required] 
    public string AccessToken { get; set; } = null!;

    [Required] 
    public string RefreshToken { get; set; } = null!;
}