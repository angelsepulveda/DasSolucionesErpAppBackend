namespace Membership.Data;

public class MembershipDbContext : DbContext
{
    public MembershipDbContext(DbContextOptions<MembershipDbContext> options)
        : base(options) { }

    public DbSet<ModuleModel> Modules => Set<ModuleModel>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<ActionModel> Actions => Set<ActionModel>();
    public DbSet<PermissionAction> PermissionActions => Set<PermissionAction>();
    public DbSet<Permission> Permissions => Set<Permission>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Membership");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
