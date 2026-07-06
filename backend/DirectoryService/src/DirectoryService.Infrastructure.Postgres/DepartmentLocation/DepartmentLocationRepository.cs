using DirectoryService.Core.DepartmentLocation;
using DirectoryService.Infrastructure.Postgres.Database;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.DepartmentLocation;

public class DepartmentLocationRepository : IDepartmentLocationRepository
{
    private readonly AppDbContext _context;

    public DepartmentLocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateWithLocations(Guid departmentId, IEnumerable<Guid> departmentLocationIds,
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
    }

    public async Task<Guid> CreateWithLocation(Domain.DepartmentLocation entity, CancellationToken ct)
    {
        await _context.DepartmentLocations.AddAsync(entity, ct);
        return entity.Id;
    }

    public async Task<bool> IsLinkExist(Guid departmentId, Guid locationId, CancellationToken ct)
    {
        return await _context.DepartmentLocations.AnyAsync(x=>x.LocationId == locationId && x.DepartmentId == departmentId,ct);
    }

    public async Task Delete(Guid departmentId, Guid locationId, CancellationToken ct)
    {
        var entity =  await _context.DepartmentLocations.FirstAsync(x=> x.DepartmentId == departmentId && x.LocationId == locationId,ct);
        _context.DepartmentLocations.Remove(entity);
    }

    public async Task Save(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
    }
}