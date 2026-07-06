namespace DirectoryService.Core.DepartmentLocation;

public interface IDepartmentLocationRepository
{
    public Task CreateWithLocations(Guid departmentId, IEnumerable<Guid> departmentLocationIds,
        CancellationToken ct);

    public Task<Guid> CreateWithLocation(Domain.DepartmentLocation entity, CancellationToken ct);
    public Task<bool> IsLinkExist(Guid departmentId, Guid locationId, CancellationToken ct);
    public Task<int> Delete(Guid departmentId, Guid locationId, CancellationToken ct);
    Task Save(CancellationToken ct);
}