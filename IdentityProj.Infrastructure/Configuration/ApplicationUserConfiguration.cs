﻿using IdentityProj.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityProj.PostgreSQL.Configuration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(p => p.TimeZone)
            .HasDefaultValue("Asia/Yerevan");

        builder.HasOne(p => p.Company)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.CompanyId);
    }
}