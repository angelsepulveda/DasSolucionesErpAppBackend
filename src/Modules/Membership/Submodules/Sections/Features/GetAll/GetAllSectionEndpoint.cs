namespace Membership.Submodules.Sections;

public class GetAllSectionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/api/sections",
                async (ISender sender) =>
                {
                    List<SectionDto> sections = await sender.Send(new GetAllSectionQuery());

                    return Results.Ok(sections);
                }
            )
            .WithName("GetAllSection")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetAll Section")
            .WithDescription("GetAll Section");
    }
}
