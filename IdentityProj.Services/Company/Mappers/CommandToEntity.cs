using AutoMapper;
using IdentityProj.Services.Company.Command.Create;
using IdentityProj.Services.Company.Command.Update;

namespace IdentityProj.Services.Company.Mappers;

public class CommandToEntity: Profile
{
    public CommandToEntity()
    {
        CreateMap<CreateCompanyCommand, Data.Entity.Company>();
        CreateMap<UpdateCompanyCommand, Data.Entity.Company>();
    }
}