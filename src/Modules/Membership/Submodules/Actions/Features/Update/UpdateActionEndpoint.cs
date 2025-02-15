namespace Membership.Submodules.Actions;

public class UpdatActionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/api/actions",
                async (UpdateActionPayload payload, ISender sender) =>
                {
                    Unit result = await sender.Send(new UpdateActionCommand(payload));

                    return Results.Ok(result);
                }
            )
            .WithName("UpdateAction")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Action")
            .WithDescription("Update Action");
    }
}
