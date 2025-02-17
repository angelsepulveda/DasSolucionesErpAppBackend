namespace Membership.Submodules.Permissions;

internal sealed class PermissionQueryEfCoreRepository(MembershipDbContext dbContext)
    : IPermissionQueryRepository
{
    public async Task<Permission?> GetByIdAsync(Guid id) =>
        await dbContext.Permissions
            .Where(x => x.Id == id && x.Status == true)
            .FirstOrDefaultAsync();

    public async Task<Permission?> GetByKeyAsync(string key) =>
        await dbContext.Permissions
            .Where(x => x.Key.Equals(key) && x.Status == true)
            .FirstOrDefaultAsync();

    public async Task<List<PermissionAction>> GetByPermissionIdAsync(Guid permissionId) =>
        await dbContext.PermissionActions.Where(x => x.PermissionId == permissionId).ToListAsync();
}
