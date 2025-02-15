using Membership.Submodules.Modules;

namespace Membership.Submodules;

public static class DependencyInjection
{
    public static IServiceCollection AddMembershipSubmodulesServices(
        this IServiceCollection services
    )
    {
        services.AddModulesServices();
        services.AddSectionsServices();

        return services;
    }
}
