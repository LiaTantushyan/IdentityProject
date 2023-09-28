using AutoMapper;
using IdentityProj.Common.Models;
using IdentityProj.Models.Response;
using IdentityProj.Models.Response.Generic;
using IdentityProj.Models.Response.User;
using IdentityProj.Services.ApplicationUsers.DTOs;

namespace IdentityProj.Mappers;

public class CommandToResponseModel : Profile
{
    public CommandToResponseModel()
    {
        CreateMap<CreateUserDto, CreateUserResponse>();
        CreateMap<UpdateUserDto, UpdateUserResponse>();
        CreateMap<ResultInfoDto, ResponseModel>();
    }
}