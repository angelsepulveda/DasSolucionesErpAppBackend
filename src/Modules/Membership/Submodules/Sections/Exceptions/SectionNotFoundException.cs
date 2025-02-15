namespace Membership.Submodules.Sections;

public class SectionNotFoundException : NotFoundException
{
    public SectionNotFoundException(Guid id)
        : base("Section", id) { }
}
