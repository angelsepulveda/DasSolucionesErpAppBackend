using Membership.Submodules.Modules.Contracts.Repositories;

namespace Membership.Submodules.Modules.Data.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddModulesRepositories(this IServiceCollection services)
    {
        services.AddScoped<IModuleQueryRepository, ModuleQueryEfCoreRepository>();

        return services;
    }
}
