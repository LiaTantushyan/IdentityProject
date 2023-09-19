using IdentityProj.Data.Entity;
using IdentityProj.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityProj.Infrastructure.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(p => p.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.ModifiedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.Status)
            .HasDefaultValue(Status.Active);
    }
}