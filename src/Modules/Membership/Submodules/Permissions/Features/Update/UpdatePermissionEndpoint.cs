namespace Membership.Submodules.Permissions;

public class UpdatePermissionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/api/permissions",
                async (UpdatePermissionPayload payload, ISender sender) =>
                {
                    Unit result = await sender.Send(new UpdatePermissionCommand(payload));

                    return Results.Ok(result);
                }
            )
            .WithName("UpdatePermission")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Permission")
            .WithDescription("Update Permission");
    }
}
