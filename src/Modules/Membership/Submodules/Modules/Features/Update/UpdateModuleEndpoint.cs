namespace Membership.Submodules.Modules.Features.Update;

public class UpdateModuleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/api/modules",
                async (UpdateModulePayload payload, ISender sender) =>
                {
                    await sender.Send(new UpdateModuleCommand(payload));

                    return Results.Ok();
                }
            )
            .WithName("UpdateModule")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update module")
            .WithDescription("Update Module");
    }
}
