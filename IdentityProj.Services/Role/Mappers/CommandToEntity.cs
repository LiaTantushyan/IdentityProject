using AutoMapper;
using IdentityProj.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Services.Role.Mappers;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        CreateMap<IdentityResult, ResultInfoDto>()
            .ForMember(x => x.Errors, y => y
                .MapFrom(z => z.Errors
                    .Select(d => d.Description)));
    }
}