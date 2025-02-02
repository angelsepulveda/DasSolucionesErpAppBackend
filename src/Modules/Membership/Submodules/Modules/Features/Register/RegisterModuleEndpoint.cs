namespace Membership.Submodules.Modules.Features.Register;

public class RegisterModuleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/modules/register",
                async (RegisterModulePayload payload, ISender sender) =>
                {
                    await sender.Send(new RegisterModuleCommand(payload));

                    return Results.Created();
                }
            )
            .WithName("RegisterModule")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register module")
            .WithDescription("Register Module");
    }
}
