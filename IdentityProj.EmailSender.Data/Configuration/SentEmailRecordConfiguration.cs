using IdentityProj.EmailSender.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityProj.EmailSender.Data.Configuration;

public class SentEmailRecordConfiguration : IEntityTypeConfiguration<SentEmailRecord>
{
    public void Configure(EntityTypeBuilder<SentEmailRecord> builder)
    {
        builder.Property(p => p.SentDate)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
    }
}