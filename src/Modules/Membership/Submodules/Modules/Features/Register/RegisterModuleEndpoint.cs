using Membership.Submodules.Modules.Dtos;

namespace Membership.Submodules.Modules.Features.Register;

public class RegisterModuleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/modules/register",
                async (RegisterModulePayload payload, ISender sender) =>
                {
                    ModuleDto result = await sender.Send(new RegisterModuleCommand(payload));

                    return Results.Ok(result);
                }
            )
            .WithName("RegisterModule")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register module")
            .WithDescription("Register Module");
    }
}
