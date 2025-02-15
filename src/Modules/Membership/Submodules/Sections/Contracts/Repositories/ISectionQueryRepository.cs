namespace Membership.Submodules.Sections;

public interface ISectionQueryRepository
{
    Task<Section?> GetByIdAsync(Guid id);
    Task<Section?> GetByKeyAsync(string key);
}
