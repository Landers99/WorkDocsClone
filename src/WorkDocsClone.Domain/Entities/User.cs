namespace WorkDocsClone.Domain.Entities;

public sealed class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Guid RootFolderId { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
};