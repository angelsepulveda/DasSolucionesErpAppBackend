namespace Membership.Submodules.Sections;

internal sealed class SectionQueryEfCoreRepository(MembershipDbContext dbContext)
    : ISectionQueryRepository
{
    public async Task<Section?> GetByIdAsync(Guid id) =>
        await dbContext.Sections.Where(x => x.Id == id && x.Status == true).FirstOrDefaultAsync();

    public async Task<Section?> GetByKeyAsync(string key) =>
        await dbContext.Sections
            .Where(x => x.Key.Equals(key) && x.Status == true)
            .FirstOrDefaultAsync();
}
