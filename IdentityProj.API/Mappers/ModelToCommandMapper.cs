using AutoMapper;
using IdentityProj.Models.Request;
using IdentityProj.Models.Request.Company;
using IdentityProj.Models.Request.User;
using IdentityProj.Services.ApplicationUsers.Command.Create;
using IdentityProj.Services.ApplicationUsers.Command.Update;
using IdentityProj.Services.Company.Command.Create;


namespace IdentityProj.Mappers;

public class ModelToCommandMapper: Profile
{
    public ModelToCommandMapper()
    {
        CreateMap<UserCreateRequest, CreateCommand>();
        CreateMap<UserUpdate, UpdateCommand>();
        CreateMap<CompanyCreate, CreateCompanyCommand>();

    }
}

