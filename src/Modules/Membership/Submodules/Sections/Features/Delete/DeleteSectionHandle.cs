namespace Membership.Submodules.Sections;

public sealed record DeleteSectionCommand(Guid Id) : ICommand;

public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
{
    public DeleteSectionCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
    }
}

internal sealed class DeleteSectionHandler(
    MembershipDbContext dbContext,
    ISectionQueryRepository sectionQueryRepository
) : ICommandHandler<DeleteSectionCommand>
{
    public async Task<Unit> Handle(
        DeleteSectionCommand request,
        CancellationToken cancellationToken
    )
    {
        Section? sectionDeleted = await sectionQueryRepository.GetByIdAsync(request.Id);

        if (sectionDeleted is null)
            throw new SectionNotFoundException(request.Id);

        sectionDeleted.Delete();

        dbContext.Sections.Update(sectionDeleted);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
