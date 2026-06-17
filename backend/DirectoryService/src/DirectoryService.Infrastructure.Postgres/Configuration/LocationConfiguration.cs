using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Domain.Location>
{
    public void Configure(EntityTypeBuilder<Domain.Location> builder)
    {
        builder.ToTable("location");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");

        builder
            .Property<Name>(l => l.Name)
            .HasConversion(l => l.Value, fdb => Name.FromDb(fdb))
            .HasMaxLength(255)
            .HasColumnName("name")
            .IsRequired();

        builder.OwnsOne(l => l.Address, address =>
        {
            address.Property(a => a.City)
                .HasColumnName("address_city")
                .HasMaxLength(100)
                .IsRequired();
            address.Property(a => a.Street)
                .HasColumnName("address_street")
                .HasMaxLength(200)
                .IsRequired();
            address.Property(a => a.HouseNumber)
                .HasColumnName("address_house_number")
                .HasMaxLength(20)
                .IsRequired();
        });

        builder
            .Property(x => x.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder
            .Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}