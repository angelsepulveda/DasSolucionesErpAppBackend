using Membership.Submodules.Permissions.Data.Repositories;

namespace Membership.Submodules.Permissions;

public static class DependencyInjection
{
    public static IServiceCollection AddPermissionsServices(this IServiceCollection services)
    {
        services.AddPermissionsRepositories();

        return services;
    }
}
