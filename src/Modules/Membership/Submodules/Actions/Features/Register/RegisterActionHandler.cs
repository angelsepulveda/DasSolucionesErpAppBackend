namespace Membership.Submodules.Actions;

public sealed record RegisterActionPayload(string Name);

public sealed record RegisterActionCommand(RegisterActionPayload Payload) : ICommand<ActionDto>;

public class RegisterActionCommandValidator : AbstractValidator<RegisterActionCommand>
{
    public RegisterActionCommandValidator()
    {
        RuleFor(x => x.Payload.Name).NotEmpty().WithMessage("Name is required");
    }
}

internal sealed class RegisterActionHandler(MembershipDbContext dbContext)
    : ICommandHandler<RegisterActionCommand, ActionDto>
{
    public async Task<ActionDto> Handle(
        RegisterActionCommand request,
        CancellationToken cancellationToken
    )
    {
        ActionModel action = ActionModel.Create(request.Payload.Name);

        dbContext.Actions.Add(action);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ActionDto(action.Id, action.Name);
    }
}
