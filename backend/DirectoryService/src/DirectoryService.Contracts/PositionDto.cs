namespace DirectoryService.Contracts;

public record PositionDto(string Name, string Description, bool IsActive);

public record CreatePositionDto(string Name, string Description, bool IsActive);

public record CreatedPositionDto(Guid Id, string Name, string Description, bool IsActive);

public record UpdatePositionDto(string Name, string Description, bool IsActive);