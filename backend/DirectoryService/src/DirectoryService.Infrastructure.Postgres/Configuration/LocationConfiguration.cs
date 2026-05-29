using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("location");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("id");

        builder
            .Property<Name>(l=> l.Name)
            .HasConversion(l => l.Value,fdb => Name.FromDb(fdb))
            .HasMaxLength(250)
            .HasColumnName("name")
            .IsRequired();

        builder
            .Property(x => x.Address)
            .HasConversion(l => l.Value,frb => Address.FromDb(frb))
            .HasMaxLength(250)
            .HasColumnName("address")
            .IsRequired();
        
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