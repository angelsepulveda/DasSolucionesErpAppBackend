namespace Membership.Submodules.Permissions;

public class PermissionKeyAlreadyExistsException : BadRequestException
{
    public PermissionKeyAlreadyExistsException()
        : base("Permission key already exists") { }
}
