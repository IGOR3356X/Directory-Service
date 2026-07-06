namespace DirectoryService.Core.Location;

public interface ILocationRepository
{
    public Task<Guid> Create(Domain.Location request, CancellationToken ct);
    public Task<Domain.Location?> GetById(Guid requestId, CancellationToken ct);
    public Task<bool> IsNameExists(string name, CancellationToken ct);
    Task<bool> IsLocationExists(IEnumerable<Guid> ids, CancellationToken ct);
    Task Save(CancellationToken ct);
}