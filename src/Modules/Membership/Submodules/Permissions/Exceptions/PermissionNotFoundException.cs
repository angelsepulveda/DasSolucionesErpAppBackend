namespace Membership.Submodules.Permissions;

public class PermissionNotFoundException : NotFoundException
{
    public PermissionNotFoundException(Guid id)
        : base("Permission", id) { }
}
