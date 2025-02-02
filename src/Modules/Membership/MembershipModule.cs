using Membership.Data.Seed;
using Membership.Submodules;
using Shared.Data;
using Shared.Data.Seed;

namespace Membership;

public static class MembershipModule
{
    public static IServiceCollection AddMembershipModule(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Add services to the container.

        // Api Endpoint services

        // Application Use Case services

        // Data - Infrastructure services
        string connectionString =
            configuration.GetConnectionString("Database")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<MembershipDbContext>(
            (sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(connectionString);
            }
        );

        services.AddScoped<IDataSeeder, MembershipDataSeeder>();
        services.AddMembershipSubmodulesServices();

        return services;
    }

    public static IApplicationBuilder UseMembershipModule(this IApplicationBuilder app)
    {
        // Configure the HTTP request pipeline.

        // 1. Use Api Endpoint services

        // 2. Use Application Use Case services

        // 3. Use Data - Infrastructure services
        app.UseMigration<MembershipDbContext>();

        return app;
    }
}
