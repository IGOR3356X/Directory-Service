using DirectoryService.Contracts;

namespace DirectoryService.Core.Department;

public class DepartmentService: IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateDepartment(CreateDepartmentDto department)
    {
        
    }
}