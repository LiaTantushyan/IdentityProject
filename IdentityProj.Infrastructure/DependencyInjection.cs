using IdentityProj.Data.Entity;
using IdentityProj.Infrastructure.Interfaces;
using IdentityProj.Infrastructure.Repositories;
using IdentityProj.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityProj.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole<int>>(opt => opt.User.RequireUniqueEmail = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}