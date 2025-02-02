using Membership.Submodules.Modules.Models;

namespace Membership.Data;

public class MembershipDbContext : DbContext
{
    public MembershipDbContext(DbContextOptions<MembershipDbContext> options)
        : base(options) { }

    public DbSet<ModuleModel> Modules => Set<ModuleModel>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Membership");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
