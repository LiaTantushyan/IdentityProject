namespace IdentityProj.Data.Entity;

public class RefreshToken
{
    public int Id { get; set; }
    
    public string? Value { get; set; }

    public string? JwtId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool Used { get; set; }

    public bool InValidated { get; set; }

    public long UserId { get; set; }

    public ApplicationUser? User { get; set; }
}