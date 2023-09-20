using AutoMapper;
using IdentityProj.Common.Models;
using IdentityProj.Data.Entity;
using IdentityProj.Services.ApplicationUsers.DTOs;
using Microsoft.AspNetCore.Identity;

namespace IdentityProj.Services.ApplicationUsers.Mappers;

public class EntityToDTO : Profile
{
    public EntityToDTO()
    {
        CreateMap<ApplicationUser, GetUserDto>();
        CreateMap<ApplicationUser, CreateUserDto>();

        CreateMap<IdentityResult, CreateUserDto>()
            .ForMember(x => x.Errors, y => y
                .MapFrom(z => z.Errors
                    .Select(d => d.Description)));
        
        CreateMap<IdentityResult, UpdateUserDto>()
            .ForMember(x => x.Errors, y => y
                .MapFrom(z => z.Errors
                    .Select(d => d.Description)));
        
        CreateMap<IdentityResult, ResultInfoDto>()
            .ForMember(x => x.Errors, y => y
                .MapFrom(z => z.Errors
                    .Select(d => d.Description)));
    }
}