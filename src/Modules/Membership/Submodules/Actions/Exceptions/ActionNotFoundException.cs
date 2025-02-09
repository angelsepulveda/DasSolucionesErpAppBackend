namespace Membership.Submodules.Actions;

public class ActionNotFoundException : NotFoundException
{
    public ActionNotFoundException(Guid id)
        : base("Action", id) { }
}
