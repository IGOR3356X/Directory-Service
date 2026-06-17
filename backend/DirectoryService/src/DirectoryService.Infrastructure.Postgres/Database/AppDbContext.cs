using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<DepartmentPosition> DepartmentPositions => Set<DepartmentPosition>();
    public DbSet<DepartmentLocation> DepartmentLocations => Set<DepartmentLocation>();
    public DbSet<Domain.Location> Locations => Set<Domain.Location>();
    public DbSet<Position> Positions => Set<Position>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}