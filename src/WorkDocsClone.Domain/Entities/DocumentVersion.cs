namespace WorkDocsClone.Domain.Entities;
using System;

public sealed class DocumentVersion
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public int VersionNumber { get; set; }
    public Guid UploadByUserId { get; set; }
    public long SizeBytes { get; set; }
    public string Sha256 { get; set; } = null!;
    public string BlobPath { get; set; } = null!;
    public string? ChangeNote { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
}
