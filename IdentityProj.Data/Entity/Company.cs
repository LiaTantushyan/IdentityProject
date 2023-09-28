using IdentityProj.Common.Enum;

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

    public Statuses Statuses { get; set; }
    
    public ICollection<ApplicationUser> Employees { get; set; }
}