namespace Membership.Submodules.Permissions;

public sealed record RegisterPermissionPayload(
    string Name,
    Guid ModuleId,
    string Key,
    string? Description,
    List<Guid> ActionsId
);

public sealed record RegisterPermissionCommand(RegisterPermissionPayload Payload)
    : ICommand<PermissionDto>;

public class RegisterPermissionCommandValidator : AbstractValidator<RegisterPermissionCommand>
{
    public RegisterPermissionCommandValidator()
    {
        RuleFor(x => x.Payload.ModuleId).NotNull();
        RuleFor(x => x.Payload.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Payload.Key).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Payload.Description).MaximumLength(150);
        RuleFor(x => x.Payload.ActionsId)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count > 0)
            .WithMessage("ActionsId must have at least one element");
    }
}

internal sealed class RegisterPermissionHandler(
    MembershipDbContext dbContext,
    IPermissionQueryRepository permissionQueryRepository,
    IPermissionActionCommandRepository permissionActionCommandRepository
) : ICommandHandler<RegisterPermissionCommand, PermissionDto>
{
    public async Task<PermissionDto> Handle(
        RegisterPermissionCommand request,
        CancellationToken cancellationToken
    )
    {
        Permission? permissionAlreadyKey = await permissionQueryRepository.GetByKeyAsync(
            request.Payload.Key
        );

        if (permissionAlreadyKey is not null)
            throw new SectionKeyAlreadyExistsException();

        Permission permission = Permission.Create(
            request.Payload.Name,
            request.Payload.ModuleId,
            request.Payload.Key,
            request.Payload.Description
        );

        foreach (Guid actionId in request.Payload.ActionsId)
        {
            permission.AddActions(actionId);
        }

        await dbContext.ExecuteTransactionAsync(
            async () =>
            {
                dbContext.Permissions.Add(permission);

                await dbContext.SaveChangesAsync(cancellationToken);

                permissionActionCommandRepository.Register(permission.Actions);

                await dbContext.SaveChangesAsync(cancellationToken);
            },
            cancellationToken
        );

        return new PermissionDto(
            permission.Id,
            permission.Name,
            permission.ModuleId,
            permission.Key,
            permission.Description
        );
    }
}
