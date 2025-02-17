namespace Membership.Submodules.Permissions;

public sealed record DeletePermissionCommand(Guid Id) : ICommand;

public class DeletePermissionCommandValidator : AbstractValidator<DeletePermissionCommand>
{
    public DeletePermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}

internal sealed class DeletePermissionHandler(
    MembershipDbContext dbContext,
    IPermissionQueryRepository permissionQueryRepository
) : ICommandHandler<DeletePermissionCommand>
{
    public async Task<Unit> Handle(
        DeletePermissionCommand request,
        CancellationToken cancellationToken
    )
    {
        Permission? permissionDeleted = await permissionQueryRepository.GetByIdAsync(request.Id);

        if (permissionDeleted is null)
            throw new SectionNotFoundException(request.Id);

        permissionDeleted.Delete();

        dbContext.Permissions.Update(permissionDeleted);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
