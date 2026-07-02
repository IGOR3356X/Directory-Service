using DirectoryService.Core.DepartmentLocation;
using DirectoryService.Infrastructure.Postgres.Database;

namespace DirectoryService.Infrastructure.Postgres.DepartmentLocation;

public class DepartmentLocationRepository : IDepartmentLocationRepository
{
    private readonly AppDbContext _context;

    public DepartmentLocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateDepartmentLocation(Guid departmentId, IEnumerable<Guid> departmentLocationIds,
        CancellationToken ct)
    {
        var distinctIds = departmentLocationIds
            .Distinct()
            .ToList();
        if (distinctIds.Count == 0)
            return;

        var links = distinctIds
            .Select(locationId => Domain.DepartmentLocation.Create(
                departmentId,
                locationId,
                false))
            .ToList();

        await _context.DepartmentLocations.AddRangeAsync(links, ct);
        await _context.SaveChangesAsync(ct);
    }
}