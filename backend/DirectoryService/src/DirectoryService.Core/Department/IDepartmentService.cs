using DirectoryService.Contracts;

namespace DirectoryService.Core.Department;

public interface IDepartmentService
{
    public Task<Guid> Create(CreateDepartmentDto request, CancellationToken ct);
}