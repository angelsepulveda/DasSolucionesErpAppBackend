namespace Membership.Submodules.Sections;

public class UpdateSectionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/api/sections",
                async (UpdateSectionPayload payload, ISender sender) =>
                {
                    Unit result = await sender.Send(new UpdateSectionCommand(payload));

                    return Results.Ok(result);
                }
            )
            .WithName("UpdateSection")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Section")
            .WithDescription("Update Section");
    }
}
