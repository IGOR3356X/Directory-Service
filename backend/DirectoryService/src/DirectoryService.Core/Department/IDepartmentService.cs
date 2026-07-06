using DirectoryService.Contracts;

namespace DirectoryService.Core.Department;

public interface IDepartmentService
{
    public Task<Guid> Create(CreateDepartmentDto request, CancellationToken ct);
    public Task<Domain.Department> GetById(Guid id, CancellationToken ct);
    public Task PartUpdate(Guid id,PartUpdateDepartmentDto request, CancellationToken ct);
}