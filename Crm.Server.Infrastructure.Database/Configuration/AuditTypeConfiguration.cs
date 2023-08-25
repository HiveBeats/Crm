using Crm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Server.Infrastructure.Database.Configuration;
public class AuditTypeConfiguration : IEntityTypeConfiguration<AuditType>
{
    public void Configure(EntityTypeBuilder<AuditType> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(128);
        builder.HasIndex(x => x.Name);
    }
}
