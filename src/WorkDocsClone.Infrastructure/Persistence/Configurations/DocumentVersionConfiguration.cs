using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkDocsClone.Domain.Entities;

namespace WorkDocsClone.Infrastructure.Persistence.Configurations;

public class DocumentVersionConfiguration : IEntityTypeConfiguration<DocumentVersion>
{
    public void Configure(EntityTypeBuilder<DocumentVersion> b)
    {
        b.ToTable("DocumentVersions");
        b.HasKey(x => x.Id);

        b.Property(x => x.VersionNumber).IsRequired();
        b.Property(x => x.SizeBytes).IsRequired();
        
        b.Property(x => x.Sha256)
            .IsRequired()
            .HasMaxLength(64);

        b.Property(x => x.BlobPath)
            .IsRequired()
            .HasMaxLength(500);

        b.Property(x => x.CreatedAtUtc).IsRequired();

        b.HasIndex(x => new { x.DocumentId, x.VersionNumber }).IsUnique();
        b.HasIndex(x => x.DocumentId);
    }
}
