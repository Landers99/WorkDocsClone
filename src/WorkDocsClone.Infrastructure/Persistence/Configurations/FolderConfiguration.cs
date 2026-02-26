using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkDocsClone.Domain.Entities;

namespace WorkDocsClone.Infrastructure.Persistence.Configurations;

public class FolderConfiguration : IEntityTypeConfiguration<Folder>
{
    public void Configure(EntityTypeBuilder<Folder> b)
    {
        b.ToTable("Folders");
        b.HasKey(x => x.Id);

        b.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        b.Property(x => x.CreatedAtUtc).IsRequired();
        b.Property(x => x.UpdatedAtUtc).IsRequired();

        b.HasIndex(x => x.OwnerUserId);
        b.HasIndex(x => x.ParentFolderId);

        b.HasIndex(x => new { x.OwnerUserId, x.ParentFolderId, x.Name }).IsUnique();
    }
}
