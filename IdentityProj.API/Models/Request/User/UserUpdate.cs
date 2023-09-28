namespace IdentityProj.Models.Request.User;

public class UserUpdate
{
    public int Id { get; set; }
    
    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? TimeZone { get; set; }
    
    public string? Password { get; set; }
}