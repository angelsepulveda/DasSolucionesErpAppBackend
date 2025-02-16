namespace Membership.Data.Configurations;

public class PermissionActionConfiguration : IEntityTypeConfiguration<PermissionAction>
{
    public void Configure(EntityTypeBuilder<PermissionAction> builder)
    {
        builder.ToTable("permissions__actions");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion(v => v.ToString(), v => Guid.Parse(v))
            .HasColumnType("char(36)")
            .HasColumnName("id");

        builder
            .Property(p => p.PermissionId)
            .HasColumnName("permission_id")
            .HasColumnType("char(36)")
            .HasConversion(v => v.ToString(), v => Guid.Parse(v))
            .IsRequired();

        builder
            .Property(p => p.ActionId)
            .HasColumnName("action_id")
            .HasColumnType("char(36)")
            .HasConversion(v => v.ToString(), v => Guid.Parse(v))
            .IsRequired();
    }
}
