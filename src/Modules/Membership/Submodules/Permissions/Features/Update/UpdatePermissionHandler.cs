namespace Membership.Submodules.Permissions;

public sealed record UpdatePermissionPayload(
    Guid Id,
    string Name,
    Guid ModuleId,
    string Key,
    string? Description,
    List<Guid> ActionsId
);

public sealed record UpdatePermissionCommand(UpdatePermissionPayload Payload) : ICommand;

public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
{
    public UpdatePermissionCommandValidator()
    {
        RuleFor(x => x.Payload.Id).NotNull();
        RuleFor(x => x.Payload.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Payload.Key).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Payload.Description).MaximumLength(256);
        RuleFor(x => x.Payload.ActionsId)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count > 0)
            .WithMessage("ActionsId must have at least one element");
    }
}

internal sealed class UpdatePermissionHandler(
    MembershipDbContext dbContext,
    IPermissionQueryRepository permissionQueryRepository,
    IPermissionActionCommandRepository permissionActionCommandRepository
) : ICommandHandler<UpdatePermissionCommand>
{
    public async Task<Unit> Handle(
        UpdatePermissionCommand request,
        CancellationToken cancellationToken
    )
    {
        Permission? permissionUpdated = await permissionQueryRepository.GetByIdAsync(
            request.Payload.Id
        );

        if (permissionUpdated is null)
            throw new PermissionNotFoundException(request.Payload.Id);

        Permission? permissionAlreadyKey = await permissionQueryRepository.GetByKeyAsync(
            request.Payload.Key
        );

        if (permissionAlreadyKey is not null && permissionAlreadyKey.Id != request.Payload.Id)
            throw new PermissionKeyAlreadyExistsException();

        permissionUpdated.Update(
            request.Payload.Name,
            request.Payload.ModuleId,
            request.Payload.Key,
            request.Payload.Description
        );

        foreach (Guid actionId in request.Payload.ActionsId)
        {
            permissionUpdated.AddActions(actionId);
        }

        await dbContext.ExecuteTransactionAsync(
            async () =>
            {
                dbContext.Permissions.Update(permissionUpdated);

                await dbContext.SaveChangesAsync(cancellationToken);

                await dbContext.PermissionActions
                    .Where(x => x.PermissionId == permissionUpdated.Id)
                    .ExecuteDeleteAsync(cancellationToken);

                permissionActionCommandRepository.Register(permissionUpdated.Actions);

                await dbContext.SaveChangesAsync(cancellationToken);
            },
            cancellationToken
        );

        return Unit.Value;
    }
}
