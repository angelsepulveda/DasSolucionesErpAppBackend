namespace Membership.Submodules.Permissions;

public class DeletePermissionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/api/permissions/{Id:guid}",
                async (Guid Id, ISender sender) =>
                {
                    Unit result = await sender.Send(new DeletePermissionCommand(Id));

                    return Results.Ok(result);
                }
            )
            .WithName("DeletePermission")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Permission")
            .WithDescription("Delete Permission");
    }
}
