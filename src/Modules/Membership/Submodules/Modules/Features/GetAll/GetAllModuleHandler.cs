using Membership.Submodules.Modules.Dtos;

namespace Membership.Submodules.Modules.Features.GetAll;

public sealed record GetAllModuleQuery() : IQuery<List<ModuleDto>>;

internal sealed class GetAllModuleHandler(MembershipDbContext dbContext)
    : IQueryHandler<GetAllModuleQuery, List<ModuleDto>>
{
    public async Task<List<ModuleDto>> Handle(
        GetAllModuleQuery request,
        CancellationToken cancellationToken
    )
    {
        List<ModuleModel> modules = await dbContext.Modules
            .Where(x => x.Status)
            .ToListAsync(cancellationToken);

        return modules.Select(x => new ModuleDto(x.Id, x.Name)).ToList();
    }
}
