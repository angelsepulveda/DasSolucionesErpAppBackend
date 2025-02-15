namespace Membership.Submodules.Sections;

public class RegisterSectionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/sections",
                async (RegisterSectionPayload payload, ISender sender) =>
                {
                    SectionDto result = await sender.Send(new RegisterSectionCommand(payload));

                    return Results.Ok(result);
                }
            )
            .WithName("RegisterSection")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register Section")
            .WithDescription("Register Section");
    }
}
