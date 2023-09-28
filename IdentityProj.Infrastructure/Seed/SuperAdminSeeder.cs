using IdentityProj.Common.Enum;
using IdentityProj.Data.Constants;
using IdentityProj.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityProj.Infrastructure.Seed;

public static class SuperAdminSeeder
{
    public static async Task InitializeAsync(IServiceProvider services, ApplicationDbContext dbContext)
    {
        var superAdmin = new ApplicationUser
        {
            Email = Supervisor.Email,
            FullName = Supervisor.FullName,
            UserName = Supervisor.UserName,
            PasswordHash = Supervisor.PasswordHash,
            PhoneNumber = Supervisor.PhoneNumber,
            NormalizedUserName = Supervisor.NormalizedUserName,
            NormalizedEmail = Supervisor.NormalizedEmail
        };

        var userManager = services.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var existingUser = await userManager.FindByEmailAsync(superAdmin.Email)
                           ?? await userManager.FindByNameAsync(superAdmin.UserName);

        if (existingUser == null)
        {
            var result = await userManager.CreateAsync(superAdmin, superAdmin.PasswordHash);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdmin, UserRoles.Supervisor.ToString());
            }
        }
        else
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            existingUser.Email = superAdmin.Email;
            existingUser.FullName = superAdmin.FullName;
            existingUser.UserName = superAdmin.UserName;
            existingUser.PhoneNumber = superAdmin.PhoneNumber;
            existingUser.NormalizedUserName = superAdmin.NormalizedUserName;
            existingUser.NormalizedEmail = superAdmin.NormalizedEmail;
            existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, superAdmin.PasswordHash);

            await userManager.UpdateAsync(existingUser);

            var isSuperAdmin = await userManager.IsInRoleAsync(existingUser, UserRoles.Supervisor.ToString());
            if (!isSuperAdmin)
            {
                await userManager.AddToRoleAsync(existingUser, UserRoles.Supervisor.ToString());
            }
        }
    }
}