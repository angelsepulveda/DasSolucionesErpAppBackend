namespace Membership.Data.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("sections");

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
    }
}
