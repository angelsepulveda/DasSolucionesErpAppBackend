using Membership.Submodules.Modules.Contracts.Repositories;
using Membership.Submodules.Modules.Exceptions;

namespace Membership.Submodules.Modules.Features.Update;

public sealed record UpdateModulePayload(Guid Id, string Name);

public sealed record UpdateModuleCommand(UpdateModulePayload Payload) : ICommand;

public class UpdateModuleCommandValidator : AbstractValidator<UpdateModuleCommand>
{
    public UpdateModuleCommandValidator()
    {
        RuleFor(x => x.Payload.Id).NotNull().WithMessage("Id is required");

        RuleFor(x => x.Payload.Name).NotEmpty().WithMessage("Name is required");
    }
}

internal sealed class UpdateModuleHandler(
    MembershipDbContext dbContext,
    IModuleQueryRepository moduleQueryRepository
) : ICommandHandler<UpdateModuleCommand>
{
    public async Task<Unit> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
    {
        ModuleModel? moduleUpdated = await moduleQueryRepository.GetByIdAsync(request.Payload.Id);

        if (moduleUpdated is null || moduleUpdated.Status == false)
            throw new ModuleNotFoundException(request.Payload.Id);

        moduleUpdated.Update(request.Payload.Name);

        dbContext.Modules.Update(moduleUpdated);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
