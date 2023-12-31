﻿using System.Reflection;
using FluentValidation;
using IdentityProj.Common.Interfaces.EmailSender;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;

namespace IdentityProj.Services
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<UserManagerRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}