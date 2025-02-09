namespace Membership.Submodules.Actions;

public sealed record DeleteActionCommand(Guid Id) : ICommand;

public class DeleteActionCommandValidator : AbstractValidator<DeleteActionCommand>
{
    public DeleteActionCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
    }
}

internal sealed class DeleteActionHandler(
    MembershipDbContext dbContext,
    IActionQueryRepository actionQueryRepository
) : ICommandHandler<DeleteActionCommand>
{
    public async Task<Unit> Handle(DeleteActionCommand request, CancellationToken cancellationToken)
    {
        ActionModel? actionDeleted = await actionQueryRepository.GetByIdAsync(request.Id);

        if (actionDeleted is null)
            throw new ActionNotFoundException(request.Id);

        actionDeleted.Delete();

        dbContext.Actions.Update(actionDeleted);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
