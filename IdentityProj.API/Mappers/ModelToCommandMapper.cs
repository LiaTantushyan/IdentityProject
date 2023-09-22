using AutoMapper;
using IdentityProj.Models.Request.Auth;
using IdentityProj.Models.Request.Company;
using IdentityProj.Models.Request.User;
using IdentityProj.Services.ApplicationUsers.Command.Create;
using IdentityProj.Services.ApplicationUsers.Command.Update;
using IdentityProj.Services.Common.Auth.Login;
using IdentityProj.Services.Common.Auth.RefreshToken;
using IdentityProj.Services.Company.Command.Create;
using IdentityProj.Services.Company.Command.Update;


namespace IdentityProj.Mappers;

public class ModelToCommandMapper: Profile
{
    public ModelToCommandMapper()
    {
        CreateMap<UserCreateRequest, CreateCommand>();
        CreateMap<UserUpdate, UpdateCommand>();
        CreateMap<CompanyCreate, CreateCompanyCommand>();
        CreateMap<CompanyUpdate, UpdateCompanyCommand>();
        CreateMap<LoginRequest, LoginCommand>();
        CreateMap<RefreshTokenRequest, RefreshTokenCommand>();
    }
}

