namespace DirectoryService.Contracts;


public record DepartmentLocationDto(Guid Id, Guid DepartmentId, Guid LocationId, bool IsPrimary);
public record CreatedDepartmentLocationDto(Guid Id, Guid DepartmentId, Guid LocationId, bool IsPrimary);
