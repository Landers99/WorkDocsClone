using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkDocsClone.Domain.Entities;

namespace WorkDocsClone.Infrastructure.Persistence.Configurations;

public class PermissionGrantConfiguration : IEntityTypeConfiguration<PermissionGrant>
{
    public void Configure(EntityTypeBuilder<PermissionGrant> b)
    {
        b.ToTable("PermissionGrants");
        b.HasKey(x => x.Id);

        b.Property(x => x.ResourceType).IsRequired();
        b.Property(x => x.ResourceId).IsRequired();
        b.Property(x => x.Role).IsRequired();
        b.Property(x => x.CreatedAtUtc).IsRequired();

        b.HasIndex(x => new { x.ResourceType, x.ResourceId, x.GrantedToUserId });

        b.HasIndex(x => new { x.ResourceType, x.ResourceId, x.GrantedToUserId })
            .IsUnique();
    }
}
