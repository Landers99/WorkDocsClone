namespace WorkDocsClone.Domain.Entities;

public sealed class Folder
{
    public Guid Id { get; set; }
    public Guid OwnerUserId { get; set; }
    public Guid? ParentFolderId { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
}