using System.ComponentModel.DataAnnotations;

namespace IdentityProj.Models.Request.User;

public class UserCreateRequest
{
    [Required] 
    public string? FullName { get; set; }

    [Required] 
    public string? Username { get; set; }

    [Required] 
    public string? Email { get; set; }
    
    [Required] 
    public string? PhoneNumber { get; set; }
    
    [Required]
    public string? TimeZone { get; set; }
    
    [Required] 
    public string? Password { get; set; }
}