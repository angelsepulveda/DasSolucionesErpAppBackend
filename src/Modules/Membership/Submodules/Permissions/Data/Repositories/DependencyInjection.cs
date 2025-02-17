namespace Membership.Submodules.Permissions.Data.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddPermissionsRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPermissionQueryRepository, PermissionQueryEfCoreRepository>();

        return services;
    }
}
