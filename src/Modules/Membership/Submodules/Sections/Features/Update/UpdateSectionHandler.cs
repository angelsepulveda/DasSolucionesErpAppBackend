namespace Membership.Submodules.Sections;

public sealed record UpdateSectionPayload(Guid Id, string Name, string Key, string? Description);

public sealed record UpdateSectionCommand(UpdateSectionPayload Payload) : ICommand;

public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionCommandValidator()
    {
        RuleFor(x => x.Payload.Id).NotNull();

        RuleFor(x => x.Payload.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Payload.Key).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Payload.Description).MaximumLength(256);
    }
}

internal sealed class UpdateSectionHandler(
    MembershipDbContext dbContext,
    ISectionQueryRepository sectionQueryRepository
) : ICommandHandler<UpdateSectionCommand>
{
    public async Task<Unit> Handle(
        UpdateSectionCommand request,
        CancellationToken cancellationToken
    )
    {
        Section? sectionUpdated = await sectionQueryRepository.GetByIdAsync(request.Payload.Id);

        if (sectionUpdated is null || sectionUpdated.Status)
            throw new SectionNotFoundException(request.Payload.Id);

        Section? sectionAlreadyKey = await sectionQueryRepository.GetByKeyAsync(
            request.Payload.Key
        );

        if (sectionAlreadyKey is not null && sectionAlreadyKey.Id != request.Payload.Id)
            throw new SectionKeyAlreadyExistsException();

        sectionUpdated.Update(
            request.Payload.Name,
            request.Payload.Key,
            request.Payload.Description
        );

        dbContext.Sections.Update(sectionUpdated);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
