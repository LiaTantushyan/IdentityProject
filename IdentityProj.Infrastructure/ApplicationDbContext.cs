﻿using System.Reflection;
using IdentityProj.Data.Entity;
using IdentityProj.Data.Enumerations;
using IdentityProj.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IdentityProj.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationIdentityRole, int,
    IdentityUserClaim<int>,
    IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DbSet<Company?> Companies { get; set; }

    public DbSet<RefreshToken?> RefreshTokens { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<ApplicationIdentityRole>().HasData(
            Enum.GetValues(typeof(Roles))
                .Cast<Roles>()
                .Select(role => new ApplicationIdentityRole
                {
                    Id = (int)role,
                    Name = role.ToString(),
                })
        );

        base.OnModelCreating(builder);
    }
}