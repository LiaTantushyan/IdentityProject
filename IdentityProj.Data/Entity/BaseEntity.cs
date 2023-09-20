namespace IdentityProj.Data.Entity;

public class BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public int? CreatedById { get; set; }

    public DateTime ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}