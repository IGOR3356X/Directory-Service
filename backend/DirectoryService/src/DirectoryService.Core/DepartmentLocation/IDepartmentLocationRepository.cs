namespace DirectoryService.Core.DepartmentLocation;

public interface IDepartmentLocationRepository
{
    public Task CreateDepartmentLocation(Guid departmentId, IEnumerable<Guid> departmentLocationIds,
        CancellationToken ct);
}