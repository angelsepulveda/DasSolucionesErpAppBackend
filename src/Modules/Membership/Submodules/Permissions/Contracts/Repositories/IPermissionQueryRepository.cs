namespace Membership.Submodules.Permissions;

public interface IPermissionQueryRepository
{
    Task<Permission?> GetByIdAsync(Guid id);
    Task<Permission?> GetByKeyAsync(string key);
    Task<List<PermissionAction>> GetByPermissionIdAsync(Guid permissionId);
}
