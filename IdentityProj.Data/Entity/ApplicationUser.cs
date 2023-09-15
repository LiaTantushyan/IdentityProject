using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Data.Entity;

public class ApplicationUser : IdentityUser<int>
{
    public string FullName { get; set; }

    public string TimeZone { get; set; }
}