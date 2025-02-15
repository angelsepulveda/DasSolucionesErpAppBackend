namespace Membership.Submodules.Actions;

public class GetAllActionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/api/actions",
                async (ISender sender) =>
                {
                    List<ActionDto> modules = await sender.Send(new GetAllActionQuery());

                    return Results.Ok(modules);
                }
            )
            .WithName("GetAllAction")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetAll Action")
            .WithDescription("GetAll Action");
    }
}
