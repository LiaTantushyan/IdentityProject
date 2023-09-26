using IdentityProj.Data.Enumerations;

namespace IdentityProj.Data.Entity;

public class Company: BaseEntity
{
    public Company()
    {
        Employees = new HashSet<ApplicationUser>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public Status Status { get; set; }
    public ICollection<ApplicationUser> Employees { get; set; }
}