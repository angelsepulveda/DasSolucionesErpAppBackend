using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Membership.Data.Configurations;

public class ActionConfiguration : IEntityTypeConfiguration<ActionModel>
{
    public void Configure(EntityTypeBuilder<ActionModel> builder)
    {
        builder.ToTable("actions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnType("char(36)").HasColumnName("id");

        builder
            .Property(p => p.Name)
            .HasColumnType("varchar(50)")
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Status).IsRequired().HasDefaultValue(true);
    }
}
