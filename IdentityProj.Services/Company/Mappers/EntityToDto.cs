using AutoMapper;
using IdentityProj.Data.Entity;
using IdentityProj.Services.Company.DTOs;

namespace IdentityProj.Services.Company.Mappers;

public class EntityToDto: Profile
{
    public EntityToDto()
    {
        CreateMap<Data.Entity.Company, CompanyDto>();
        CreateMap<ApplicationUser, EmployeeDto>();
    }
}