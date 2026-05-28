using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class PositionConfiguration: IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("position");
        
        builder.HasKey(p => p.Id).HasName("id");
        
        builder
            .Property<Name>(x=> x.Name)
            .HasConversion(n => n.Value,fdb => Name.Create(fdb))
            .HasMaxLength(250)
            .HasColumnName("name")
            .IsRequired();
        
        builder
            .Property(x=> x.Description)
            .HasMaxLength(250)
            .HasColumnName("description")
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