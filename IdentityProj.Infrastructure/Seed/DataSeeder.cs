using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityProj.Infrastructure.Seed;

public static class DataSeeder
{
    public static WebApplication SeedAsync(this WebApplication app, IServiceProvider services)
    {
        var context = services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

        RoleSeeder.InitilizeAsync(services.CreateScope().ServiceProvider, context).Wait();
        SuperAdminSeeder.InitializeAsync(services.CreateScope().ServiceProvider, context).Wait();

        return app;
    }
}