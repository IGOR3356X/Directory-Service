namespace DirectoryService.Core.DepartmentLocation;

public interface IDepartmentLocationService
{
    Task<Guid> CreateLink(Guid departmentId, Guid locationId, bool isPrimary, CancellationToken ct);
    Task DeleteLink(Guid departmentId, Guid locationId, CancellationToken ct);
}
