using IdentityProj.Data.Enumerations;

namespace IdentityProj.Models.Request.Company;

public class CompanyUpdate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public Status? Status { get; set; }
}