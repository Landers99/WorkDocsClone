namespace WorkDocsClone.Domain.Entities;

public sealed class Document
{
    public Guid Id { get; set; }
    public Guid FolderId { get; set; }
    public Guid OwnerUserId { get; set; }
    public string Name { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public Guid? CurrentVersionId { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
}
