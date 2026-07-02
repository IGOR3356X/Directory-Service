using DirectoryService.Core.Department;
using DirectoryService.Infrastructure.Postgres.Database;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure.Postgres.Department;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateDepartment(Domain.Department department, CancellationToken ct)
    {
        await _context.Departments.AddAsync(department, ct);
        await _context.SaveChangesAsync(ct);
        return department.Id;
    }

    public async Task<Domain.Department?> GetDepartmentById(Guid departmentId, CancellationToken ct)
    {
        return await _context.Departments.FirstOrDefaultAsync(x => x.Id == departmentId, ct);
    }
}