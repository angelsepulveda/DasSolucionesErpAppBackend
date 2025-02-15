using Membership.Submodules.Actions.Data.Repositories;

namespace Membership.Submodules.Actions;

public static class DependencyInjection
{
    public static IServiceCollection AddActionsServices(this IServiceCollection services)
    {
        services.AddActionsRepositories();

        return services;
    }
}
