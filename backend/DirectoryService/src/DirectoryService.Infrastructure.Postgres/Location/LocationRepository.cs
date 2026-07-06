using DirectoryService.Core.Location;
using DirectoryService.Domain.ValueObjects;
using DirectoryService.Infrastructure.Postgres.Database;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Location;

public class LocationRepository : ILocationRepository
{
    private readonly AppDbContext _context;

    public LocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Domain.Location request, CancellationToken ct)
    {
        var entity = await _context.Locations.AddAsync(request, ct);
        await _context.SaveChangesAsync(ct);
        return entity.Entity.Id;
    }

    public async Task<Domain.Location?> GetById(Guid requestId, CancellationToken ct)
    {
        return await _context.Locations.FirstOrDefaultAsync(x => x.Id == requestId, ct);
    }

    public async Task<bool> IsNameExists(string name, CancellationToken ct)
    {
        var target = Name.Create(name);
        return await _context.Locations.AnyAsync(d => d.Name == target, ct);
    }

    public async Task<bool> IsLocationExists(IEnumerable<Guid> ids, CancellationToken ct)
    {
        var idList = ids
            .Distinct()
            .ToList();
        if (idList.Count == 0)
            return false;

        var existingCount = await _context.Locations
            .AsNoTracking()
            .CountAsync(x => idList.Contains(x.Id), ct);

        return existingCount == idList.Count;
    }

    public async Task Save(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
    }
}