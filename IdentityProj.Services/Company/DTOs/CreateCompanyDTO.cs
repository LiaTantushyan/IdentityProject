using IdentityProj.Data.Enumerations;

namespace IdentityProj.Services.Company.DTOs;

public class CreateCompanyDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public Status Status { get; set; }
}