namespace Membership.Submodules.Permissions;

public class RegisterSectionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/permissions",
                async (RegisterPermissionPayload payload, ISender sender) =>
                {
                    PermissionDto result = await sender.Send(
                        new RegisterPermissionCommand(payload)
                    );

                    return Results.Ok(result);
                }
            )
            .WithName("RegisterPermission")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register Permission")
            .WithDescription("Register Permission");
    }
}
