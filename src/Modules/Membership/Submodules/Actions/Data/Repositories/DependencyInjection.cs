namespace Membership.Submodules.Actions.Data.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddActionsRepositories(this IServiceCollection services)
    {
        services.AddScoped<IActionQueryRepository, ActionQueryEfCoreRepository>();

        return services;
    }
}
