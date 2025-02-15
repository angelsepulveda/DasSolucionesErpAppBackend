using Membership.Submodules.Sections.Data.Repositories;

namespace Membership.Submodules.Sections;

public static class DependencyInjection
{
    public static IServiceCollection AddSectionsServices(this IServiceCollection services)
    {
        services.AddSectionsRepositories();

        return services;
    }
}
