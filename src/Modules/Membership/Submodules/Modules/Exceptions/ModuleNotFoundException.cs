namespace Membership.Submodules.Modules.Exceptions;

public class ModuleNotFoundException : NotFoundException
{
    public ModuleNotFoundException(Guid id)
        : base("Module", id) { }
}
