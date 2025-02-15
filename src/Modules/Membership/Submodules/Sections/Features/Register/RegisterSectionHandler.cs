namespace Membership.Submodules.Sections;

public sealed record RegisterSectionPayload(string Name, string Key, string? Description);

public sealed record RegisterSectionCommand(RegisterSectionPayload Payload) : ICommand<SectionDto>;

public class RegisterSectionCommandValidator : AbstractValidator<RegisterSectionCommand>
{
    public RegisterSectionCommandValidator()
    {
        RuleFor(x => x.Payload.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Payload.Key).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Payload.Description).MaximumLength(150);
    }
}

internal sealed class RegisterSectionHandler(
    MembershipDbContext dbContext,
    ISectionQueryRepository sectionQueryRepository
) : ICommandHandler<RegisterSectionCommand, SectionDto>
{
    public async Task<SectionDto> Handle(
        RegisterSectionCommand request,
        CancellationToken cancellationToken
    )
    {
        Section? sectionAlreadyKey = await sectionQueryRepository.GetByKeyAsync(
            request.Payload.Key
        );

        if (sectionAlreadyKey is not null)
            throw new SectionKeyAlreadyExistsException();

        Section section = Section.Create(
            request.Payload.Name,
            request.Payload.Key,
            request.Payload.Description
        );

        dbContext.Sections.Add(section);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new SectionDto(section.Id, section.Name, section.Key, section.Description);
    }
}
