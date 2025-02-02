using Membership.Submodules.Modules.Dtos;

namespace Membership.Submodules.Modules.Features.GetAll;

public class GetAllModuleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/api/modules/get-all",
                async (ISender sender) =>
                {
                    List<ModuleDto> modules = await sender.Send(new GetAllModuleQuery());

                    return Results.Ok(modules);
                }
            )
            .WithName("GetAllModule")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("GetAll Module")
            .WithDescription("GetAll Module");
    }
}
