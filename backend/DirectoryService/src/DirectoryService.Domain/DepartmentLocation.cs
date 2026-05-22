namespace DirectoryService.Domain;

public sealed class DepartmentLocation
{
    public DepartmentLocation(Guid departmentId, Guid locationId)
    {
        if (Guid.Empty == departmentId) throw new ArgumentException("departmentId не может быть Guid.Empty.",nameof(departmentId));
        if (Guid.Empty == locationId) throw new ArgumentException("locationId не может быть Guid.Empty.",nameof(locationId));

        Id = Guid.CreateVersion7();
        DepartmentId = departmentId;
        LocationId = locationId;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }
    public DateTime CreatedAt { get; private set; }
}