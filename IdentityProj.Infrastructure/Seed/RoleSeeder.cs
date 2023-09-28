using IdentityProj.Common.Enum;
using IdentityProj.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace IdentityProj.Infrastructure.Seed;

public static class RoleSeeder
{
    public static async Task InitilizeAsync(IServiceProvider services, ApplicationDbContext dbContext)
    {
        bool changed = false;

        var selectRoles = await dbContext.Roles.ToListAsync();

        var roles = Enum.GetValues<UserRoles>();

        foreach (var role in roles)
        {
            if (selectRoles.Any(i => i.Id == (int)role && i.NormalizedName != role.ToString().ToUpper()))
            {
                var identityRole = selectRoles.FirstOrDefault(i => i.Id == (int)role);

                identityRole!.Name = role.ToString();
                identityRole!.NormalizedName = role.ToString().ToUpper();

                changed = true;
            }

            if (!selectRoles.Any(i => i.Id == (int)role && i.NormalizedName == role.ToString().ToUpper()))
            {
                await dbContext.Roles.AddAsync(new ApplicationIdentityRole
                {
                    Id = (int)role,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper()
                });

                changed = true;
            }
        }

        if (changed)
        {
            await dbContext.SaveChangesAsync();
        }
    }
}