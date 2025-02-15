namespace Membership.Submodules.Sections;

public class SectionKeyAlreadyExistsException : BadRequestException
{
    public SectionKeyAlreadyExistsException()
        : base("Section key already exists") { }
}
