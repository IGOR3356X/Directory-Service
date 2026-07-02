using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<Domain.DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<Domain.DepartmentLocation> builder)
    {
        builder.ToTable("department_location");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.DepartmentId).HasColumnName("department_id");
        builder.Property(x => x.LocationId).HasColumnName("location_id");
        builder.Property(x => x.IsPrimary).HasColumnName("is_primary");

        builder
            .HasOne<Domain.Department>()
            .WithMany()
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<Domain.Location>()
            .WithMany()
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasIndex(x => new { x.DepartmentId, x.LocationId })
            .IsUnique();
    }
}