namespace DirectoryService.Contracts;

public record CreateLocationDto(string Name, string City,string Street, string HouseNumber, bool IsActive);
public record CreatedLocationDto(Guid Id, string Name, string City,string Street, string HouseNumber, bool IsActive);
public record UpdateLocationDto(string Name, string City,string Street, string HouseNumber, bool IsActive);