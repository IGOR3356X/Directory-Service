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
            .HasConversion(n => n.ToString(),fdt => Name.Create(fdt))
            .HasMaxLength(250)
            .IsRequired();
        
        builder
            .Property(x => x.Slug)
            .HasConversion(x => x.ToString(), fdt => Slug.Create(fdt))
            .HasMaxLength(150)
            .IsRequired();
        
        builder
            .Property(x => x.Path)
            .HasConversion(x => x.ToString(), fdt => Path.FromDb(fdt))
            .HasMaxLength(150)
            .IsRequired();
        
        
    }
}