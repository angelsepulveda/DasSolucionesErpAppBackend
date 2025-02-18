namespace Membership.Submodules.Permissions;

public interface IPermissionActionCommandRepository
{
    void Register(IReadOnlyList<PermissionAction> permissionActions);
}
