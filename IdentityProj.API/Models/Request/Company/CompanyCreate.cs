using System.ComponentModel.DataAnnotations;
using IdentityProj.Data.Enumerations;

namespace IdentityProj.Models.Request.Company;

public class CompanyCreate
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    public Status Status { get; set; }
}