using IdentityProj.Data.Entity;
using IdentityProj.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityProj.PostgreSQL.Configuration;

public class ApplicationIdentityRoleConfiguration : IEntityTypeConfiguration<ApplicationIdentityRole>
{
    public void Configure(EntityTypeBuilder<ApplicationIdentityRole> builder)
    {
        builder.HasData(
            Enum.GetValues(typeof(Roles))
                .Cast<Roles>()
                .Select(role => new ApplicationIdentityRole
                {
                    Id = (int)role,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper(),
                })
        );
    }
}