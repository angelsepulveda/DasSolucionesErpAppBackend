using Membership.Submodules.Modules.Contracts.Repositories;
using Membership.Submodules.Modules.Models;

namespace Membership.Submodules.Modules.Data.Repositories;

internal sealed class ModuleQueryEfCoreRepository(MembershipDbContext dbContext)
    : IModuleQueryRepository
{
    public async Task<ModuleModel?> GetByIdAsync(Guid id) =>
        await dbContext.Modules.Where(x => x.Id == id).FirstOrDefaultAsync();
}
