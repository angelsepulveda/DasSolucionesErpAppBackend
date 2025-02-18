namespace Membership.Submodules.Permissions;

public sealed record PermissionDto(
    Guid Id,
    string Name,
    Guid ModuleId,
    string Key,
    string? Description
);
