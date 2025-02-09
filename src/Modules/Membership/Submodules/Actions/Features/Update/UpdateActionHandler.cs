namespace Membership.Submodules.Actions;

public sealed record UpdateActionPayload(Guid Id, string Name);

public sealed record UpdateActionCommand(UpdateActionPayload Payload) : ICommand;

public class UpdateActionCommandValidator : AbstractValidator<UpdateActionCommand>
{
    public UpdateActionCommandValidator()
    {
        RuleFor(x => x.Payload.Id).NotNull().WithMessage("Id is required");

        RuleFor(x => x.Payload.Name).NotEmpty().WithMessage("Name is required");
    }
}

internal sealed class UpdateActionHandler(
    MembershipDbContext dbContext,
    IActionQueryRepository actionQueryRepository
) : ICommandHandler<UpdateActionCommand>
{
    public async Task<Unit> Handle(UpdateActionCommand request, CancellationToken cancellationToken)
    {
        ActionModel? actionUpdated = await actionQueryRepository.GetByIdAsync(request.Payload.Id);

        if (actionUpdated is null || actionUpdated.Status == false)
            throw new ActionNotFoundException(request.Payload.Id);

        actionUpdated.Update(request.Payload.Name);

        dbContext.Actions.Update(actionUpdated);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
