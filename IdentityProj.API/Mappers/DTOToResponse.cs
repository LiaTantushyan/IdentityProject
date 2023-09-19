using AutoMapper;
using IdentityProj.Common.Models;
using IdentityProj.Models.Response;
using IdentityProj.Models.Response.User;
using IdentityProj.Services.ApplicationUsers.DTOs;

namespace IdentityProj.Mappers;

public class DtoToResponse : Profile
{
    public DtoToResponse()
    {
        CreateMap<CreateUserDTO, CreateUserResponse>();
        CreateMap<UpdateUserDto, UpdateUserResponse>();
        CreateMap<ResultInfoDTO, ResponseModel>();
    }
}