using AutoMapper;
using IdentityProj.Services.Company.Command.Create;
using IdentityProj.Services.Company.Command.Update;

namespace IdentityProj.Services.Company.Mappers;

public class CommandToEntity: Profile
{
    public CommandToEntity()
    {
        CreateMap<CreateCompanyCommand, Data.Entity.Company>()
            .ForMember(opt=>opt.CreatedById, v=>v.MapFrom(i=>i.UserId))
            .ForMember(opt=>opt.ModifiedBy, v=>v.MapFrom(i=>i.UserId));
        CreateMap<UpdateCompanyCommand, Data.Entity.Company>()
            .ForMember(opt=>opt.ModifiedBy, v=>v.MapFrom(i=>i.UserId));
    }
}