using AutoMapper;
using IdentityProj.Data.Entity;
using IdentityProj.Services.ApplicationUsers.Command.Create;
using IdentityProj.Services.ApplicationUsers.Command.Update;

namespace IdentityProj.Services.ApplicationUsers.Mappers;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        CreateMap<CreateCommand, ApplicationUser>()
            .ForMember(f => f.PasswordHash,
                opt => opt.MapFrom(i => i.Password));
        
        CreateMap<UpdateCommand, ApplicationUser>()
            .ForMember(f => f.PasswordHash,
                opt => opt.MapFrom(i => i.Password));
    }
}