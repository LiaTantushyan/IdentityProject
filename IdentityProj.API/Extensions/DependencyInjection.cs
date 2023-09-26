﻿using System.Text;
using IdentityProj.Common.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace IdentityProj.Extensions;

public static class DependencyInjection
{
    public static void AddConfigurations(this IServiceCollection service, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(jwtSettings), jwtSettings);
        service.AddSingleton(jwtSettings);
        
        // Setup authentication
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };

        service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });

        service.AddSingleton(tokenValidationParameters);
    }
}