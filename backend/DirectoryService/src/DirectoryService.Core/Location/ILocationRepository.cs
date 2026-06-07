
namespace DirectoryService.Core.Location;

public interface ILocationRepository
{
    public Task<Guid> Create(Domain.Location request,CancellationToken ct);
    public Task<bool> IsNameExists(string name, CancellationToken ct);
}