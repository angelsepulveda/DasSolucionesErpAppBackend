namespace Membership.Submodules.Actions;

public class RegisterActionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/actions",
                async (RegisterActionPayload payload, ISender sender) =>
                {
                    ActionDto result = await sender.Send(new RegisterActionCommand(payload));

                    return Results.Ok(result);
                }
            )
            .WithName("RegisterAction")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register Action")
            .WithDescription("Register Action");
    }
}
