namespace Membership.Submodules.Modules.Contracts.Repositories;

public interface IModuleQueryRepository
{
    Task<ModuleModel?> GetByIdAsync(Guid id);
}
