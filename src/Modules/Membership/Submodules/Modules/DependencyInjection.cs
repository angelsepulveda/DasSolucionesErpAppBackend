using Membership.Submodules.Modules.Data.Repositories;

namespace Membership.Submodules.Modules;

public static class DependencyInjection
{
    public static IServiceCollection AddModulesServices(this IServiceCollection services)
    {
        services.AddModulesRepositories();

        return services;
    }
}
