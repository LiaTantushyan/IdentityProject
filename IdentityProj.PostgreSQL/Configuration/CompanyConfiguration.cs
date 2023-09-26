using IdentityProj.Data.Entity;
using IdentityProj.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityProj.PostgreSQL.Configuration;

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
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.ModifiedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
        
        builder.Property(p => p.Status)
            .HasDefaultValue(Status.Active);
    }
}