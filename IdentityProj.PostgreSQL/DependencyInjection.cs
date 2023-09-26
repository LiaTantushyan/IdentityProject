using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityProj.PostgreSQL;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, ApplicationIdentityRole>(opt => opt.User.RequireUniqueEmail = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddAspNetIdentity<ApplicationUser>()
            .AddInMemoryClients(new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    AllowedScopes = { "openid", "profile", "api1" }
                }
            });
    }
}