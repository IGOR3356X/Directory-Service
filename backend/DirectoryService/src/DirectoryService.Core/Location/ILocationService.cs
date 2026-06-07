using DirectoryService.Contracts;

namespace DirectoryService.Core.Location;

public interface ILocationService
{
    public Task<Guid> Create(CreateLocationDto request, CancellationToken ct);
}