namespace Membership.Submodules.Sections;

public sealed record GetAllSectionQuery() : IQuery<List<SectionDto>>;

internal sealed class GetAllSectionHandler(MembershipDbContext dbContext)
    : IQueryHandler<GetAllSectionQuery, List<SectionDto>>
{
    public async Task<List<SectionDto>> Handle(
        GetAllSectionQuery request,
        CancellationToken cancellationToken
    )
    {
        List<Section> sections = await dbContext.Sections
            .Where(x => x.Status)
            .ToListAsync(cancellationToken);

        return sections.Select(x => new SectionDto(x.Id, x.Name, x.Key, x.Description)).ToList();
    }
}
