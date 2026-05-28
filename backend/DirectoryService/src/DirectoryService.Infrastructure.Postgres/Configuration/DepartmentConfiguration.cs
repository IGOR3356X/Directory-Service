using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Path = DirectoryService.Domain.Path;

namespace DirectoryService.Infrastructure.Postgres.Configuration;

public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department");
        
        builder.HasKey(x => x.Id).HasName("id");
        
        builder
            .Property<Name>(x=> x.Name)
            .HasConversion(n => n.Value,fdb => Name.Create(fdb))
            .HasMaxLength(250)
            .HasColumnName("name")
            .IsRequired();
        
        builder
            .Property(x => x.Slug)
            .HasConversion(x => x.Value, fdb => Slug.Create(fdb))
            .HasMaxLength(150)
            .HasColumnName("slug")
            .IsRequired();
        
        builder
            .Property(x => x.Path)
            .HasConversion(x => x.Value, fdb => Path.FromDb(fdb))
            .HasMaxLength(150)
            .HasColumnName("path")
            .IsRequired(false);

        builder
            .Property(x => x.ParentId)
            .HasColumnName("parent_id")
            .IsRequired(false);
        
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