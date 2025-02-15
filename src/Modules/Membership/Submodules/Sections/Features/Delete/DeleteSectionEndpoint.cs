namespace Membership.Submodules.Sections;

public class DeleteSectionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/api/sections/{Id:guid}",
                async (Guid Id, ISender sender) =>
                {
                    Unit result = await sender.Send(new DeleteSectionCommand(Id));

                    return Results.Ok(result);
                }
            )
            .WithName("DeleteSection")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Section")
            .WithDescription("Delete Section");
    }
}
