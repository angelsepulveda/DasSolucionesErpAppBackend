namespace Membership.Submodules.Permissions;

internal sealed class PermissionActionCommandEfCoreRepository(MembershipDbContext dbContext)
    : IPermissionActionCommandRepository
{
    public void Register(IReadOnlyList<PermissionAction> permissionActions) =>
        dbContext.PermissionActions.AddRange(permissionActions);
}
