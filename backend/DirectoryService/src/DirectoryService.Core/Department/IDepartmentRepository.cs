namespace DirectoryService.Core.Department;



public interface IDepartmentRepository
{
    public Task<Guid> CreateDepartment(Domain.Department department);
}