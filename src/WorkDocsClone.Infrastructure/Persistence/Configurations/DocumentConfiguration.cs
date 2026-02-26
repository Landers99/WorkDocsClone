using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkDocsClone.Domain.Entities;

namespace WorkDocsClone.Infrastructure.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> b)
    {
        b.ToTable("Documents");
        b.HasKey(x => x.Id);

        b.Property(x => x.Name).IsRequired().HasMaxLength(260);

        b.Property(x => x.ContentType).IsRequired().HasMaxLength(200);

        b.Property(x => x.CreatedAtUtc).IsRequired();
        b.Property(x => x.UpdatedAtUtc).IsRequired();

        b.HasIndex(x => x.FolderId);
        b.HasIndex(x => x.OwnerUserId);

        b.HasIndex(x => new { x.FolderId, x.Name }).IsUnique();
    }
}
