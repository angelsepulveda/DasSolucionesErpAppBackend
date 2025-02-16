namespace Membership.Data.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion(v => v.ToString(), v => Guid.Parse(v))
            .HasColumnType("char(36)")
            .HasColumnName("id");

        builder
            .Property(p => p.ModuleId)
            .HasColumnName("module_id")
            .HasColumnType("char(36)")
            .HasConversion(v => v.ToString(), v => Guid.Parse(v))
            .IsRequired();

        builder
            .Property(p => p.Name)
            .HasColumnType("varchar(50)")
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.Key)
            .HasColumnType("varchar(150)")
            .HasColumnName("key")
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasColumnType("varchar(256)")
            .HasColumnName("description")
            .HasMaxLength(256);

        builder.Property(p => p.Status).IsRequired().HasDefaultValue(true);

        builder
            .HasOne(p => p.Module)
            .WithMany(m => m.Permissions)
            .HasForeignKey(p => p.ModuleId)
            .HasConstraintName("FK_Permissions_Module")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
