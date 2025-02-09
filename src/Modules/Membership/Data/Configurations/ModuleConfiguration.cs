using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Membership.Data.Configurations;

public class ModuleConfiguration : IEntityTypeConfiguration<ModuleModel>
{
    public void Configure(EntityTypeBuilder<ModuleModel> builder)
    {
        builder.ToTable("modules");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion(v => v.ToString(), v => Guid.Parse(v))
            .HasColumnType("char(36)")
            .HasColumnName("id");

        builder
            .Property(p => p.Name)
            .HasColumnType("varchar(50)")
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Status).IsRequired().HasDefaultValue(true);
    }
}
