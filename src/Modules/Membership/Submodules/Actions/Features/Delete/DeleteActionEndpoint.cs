namespace Membership.Submodules.Actions;

public class DeleteActionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/api/actions/delete/{Id:guid}",
                async (Guid Id, ISender sender) =>
                {
                    Unit result = await sender.Send(new DeleteActionCommand(Id));

                    return Results.Ok(result);
                }
            )
            .WithName("DeleteAction")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete action")
            .WithDescription("Delete action");
    }
}
