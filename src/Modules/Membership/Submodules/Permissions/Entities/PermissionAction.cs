namespace Membership.Submodules.Permissions;

public class PermissionAction : Entity<Guid>
{
    public Guid PermissionId { get; private set; }
    public Guid ActionId { get; private set; }

    private PermissionAction(Guid id, Guid permissionId, Guid actionId)
    {
        Id = id;
        PermissionId = permissionId;
        ActionId = actionId;
    }

    public static PermissionAction Create(Guid permissionId, Guid actionId)
    {
        Guid id = Guid.NewGuid();

        return new PermissionAction(id, permissionId, actionId);
    }
}
