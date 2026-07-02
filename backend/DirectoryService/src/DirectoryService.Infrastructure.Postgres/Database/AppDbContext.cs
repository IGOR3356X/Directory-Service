using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Department> Departments => Set<Domain.Department>();
    public DbSet<DepartmentPosition> DepartmentPositions => Set<DepartmentPosition>();
    public DbSet<Domain.DepartmentLocation> DepartmentLocations => Set<Domain.DepartmentLocation>();
    public DbSet<Domain.Location> Locations => Set<Domain.Location>();
    public DbSet<Position> Positions => Set<Position>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}