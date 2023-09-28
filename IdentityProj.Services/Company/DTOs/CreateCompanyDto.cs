using IdentityProj.Common.Enum;

namespace IdentityProj.Services.Company.DTOs;

public class CreateCompanyDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public Statuses Statuses { get; set; }
}