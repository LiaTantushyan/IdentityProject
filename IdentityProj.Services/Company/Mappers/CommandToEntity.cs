using AutoMapper;
using IdentityProj.Services.Company.Command.Create;

namespace IdentityProj.Services.Company.Mappers;

public class CommandToEntity: Profile
{
    public CommandToEntity()
    {
        CreateMap<CreateCompanyCommand, Data.Entity.Company>();
    }
}