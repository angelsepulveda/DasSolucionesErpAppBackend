using Membership.Submodules.Modules.Dtos;

namespace Membership.Submodules.Modules.Features.Register;

public sealed record RegisterModulePayload(string Name);

public sealed record RegisterModuleCommand(RegisterModulePayload Payload) : ICommand<ModuleDto>;

public class RegisterModuleCommandValidator : AbstractValidator<RegisterModuleCommand>
{
    public RegisterModuleCommandValidator()
    {
        RuleFor(x => x.Payload.Name).NotEmpty().WithMessage("Name is required");
    }
}

internal sealed class RegisterModuleHandler(MembershipDbContext dbContext)
    : ICommandHandler<RegisterModuleCommand, ModuleDto>
{
    public async Task<ModuleDto> Handle(
        RegisterModuleCommand request,
        CancellationToken cancellationToken
    )
    {
        ModuleModel module = ModuleModel.Create(request.Payload.Name);

        dbContext.Modules.Add(module);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new ModuleDto(module.Id, module.Name);
    }
}
