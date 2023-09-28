using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Data.Entity;

public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser()
    {
        RefreshTokens = new HashSet<RefreshToken>();
    }

    public string FullName { get; set; }

    public string TimeZone { get; set; }

    public int? CompanyId { get; set; }

    public Company? Company { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; }
}