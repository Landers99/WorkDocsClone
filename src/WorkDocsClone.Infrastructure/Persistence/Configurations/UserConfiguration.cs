using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkDocsClone.Domain.Entities;

namespace WorkDocsClone.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("Users");
        b.HasKey(x => x.Id);

        b.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(320);

        b.HasIndex(x => x.Email).IsUnique();

        b.Property(x => x.DisplayName)
            .IsRequired()
            .HasMaxLength(100);

        b.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        b.Property(x => x.CreatedAtUtc)
            .IsRequired();

        b.Property(x => x.RootFolderId)
            .IsRequired();
    }
}
