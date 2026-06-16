using DirectoryService.Core.Location;
using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Location;

public class LocationRepository: ILocationRepository
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

    public async Task<bool> IsNameExists(string name, CancellationToken ct)
    {
        var target = Name.Create(name);
        return await _context.Locations.AnyAsync(d => d.Name == target, ct);
    }
}