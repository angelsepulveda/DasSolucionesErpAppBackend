namespace Membership.Submodules.Actions;

public interface IActionQueryRepository
{
    Task<ActionModel?> GetByIdAsync(Guid id);
}
