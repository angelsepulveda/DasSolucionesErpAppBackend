namespace Membership.Submodules.Actions;

internal sealed class ActionQueryEfCoreRepository(MembershipDbContext dbContext)
    : IActionQueryRepository
{
    public async Task<ActionModel?> GetByIdAsync(Guid id) =>
        await dbContext.Actions.Where(x => x.Id == id && x.Status == true).FirstOrDefaultAsync();
}
