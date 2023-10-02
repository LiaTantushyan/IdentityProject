using System.Reflection;
using IdentityProj.EmailSender.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace IdentityProj.EmailSender.Data;

public class EmailSenderDbContext : DbContext
{
    public DbSet<SentEmailRecord> SentEmailRecords { get; set; } = null!;

    public EmailSenderDbContext(DbContextOptions<EmailSenderDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}