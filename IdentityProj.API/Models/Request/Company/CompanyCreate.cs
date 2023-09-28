using System.ComponentModel.DataAnnotations;
using IdentityProj.Common.Enum;

namespace IdentityProj.Models.Request.Company;

public class CompanyCreate
{
    [Required] 
    public string Name { get; set; } = null!;

    [Required] 
    public string Address { get; set; } = null!;

    public Statuses? Status { get; set; }
}