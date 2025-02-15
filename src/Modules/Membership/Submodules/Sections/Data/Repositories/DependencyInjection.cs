namespace Membership.Submodules.Sections.Data.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddSectionsRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISectionQueryRepository, SectionQueryEfCoreRepository>();

        return services;
    }
}
