namespace WorkDocsClone.Domain.Entities;

public sealed class PermissionGrant
{
    public Guid Id { get; set; }
    public ResourceType ResourceType { get; set; }
    public Guid ResourceId { get; set; }
    public Guid GrantedToUserId { get; set; }
    public PermissionRole Role { get; set; }
    public Guid GrantedByUserId { get; set; }
    public DateTimeOffSet CreatedAtUtc { get; set; }
}
