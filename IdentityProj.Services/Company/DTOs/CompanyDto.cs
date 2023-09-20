using IdentityProj.Data.Enumerations;

namespace IdentityProj.Services.Company.DTOs;

public class CompanyDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public Status? Status { get; set; }

    public List<EmployeeDto>? Employees { get; set; }
}