namespace Membership.Submodules.Actions;

public sealed record GetAllActionQuery() : IQuery<List<ActionDto>>;

internal sealed class GetAllActionHandler(MembershipDbContext dbContext)
    : IQueryHandler<GetAllActionQuery, List<ActionDto>>
{
    public async Task<List<ActionDto>> Handle(
        GetAllActionQuery request,
        CancellationToken cancellationToken
    )
    {
        List<ActionModel> actions = await dbContext.Actions
            .Where(x => x.Status)
            .ToListAsync(cancellationToken);

        return actions.Select(x => new ActionDto(x.Id, x.Name)).ToList();
    }
}
