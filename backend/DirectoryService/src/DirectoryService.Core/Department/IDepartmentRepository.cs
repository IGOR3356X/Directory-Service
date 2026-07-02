namespace DirectoryService.Core.Department;

public interface IDepartmentRepository
{
    public Task<Guid> CreateDepartment(Domain.Department department, CancellationToken ct);
    public Task<Domain.Department?> GetDepartmentById(Guid departmentId, CancellationToken ct);
}