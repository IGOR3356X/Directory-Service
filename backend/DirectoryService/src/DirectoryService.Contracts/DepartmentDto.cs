namespace DirectoryService.Contracts;

public record DepartmentDto(string Name, string Slug, Guid? ParentId, string? ParentPath, bool IsActive);

public record CreateDepartmentDto(
    string Name,
    string Slug,
    Guid? ParentId,
    IEnumerable<Guid>? LocationIds,
    bool IsActive);

public record CreatedDepartmentDto(
    Guid Id,
    string Name,
    string? Slug,
    Guid? ParentId,
    IEnumerable<Guid>? LocationIds,
    bool IsActive);

public record UpdateDepartmentDto(string Name, string Slug, Guid? ParentId, string? ParentPath, bool IsActive);