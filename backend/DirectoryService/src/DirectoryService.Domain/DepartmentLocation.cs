namespace DirectoryService.Domain;

public sealed class DepartmentLocation
{
    private DepartmentLocation()
    {
    }

    public DepartmentLocation(Guid departmentId, Guid locationId, bool isPrimary)
    {
        if (Guid.Empty == departmentId)
            throw new ArgumentException("departmentId не может быть Guid.Empty.", nameof(departmentId));
        if (Guid.Empty == locationId)
            throw new ArgumentException("locationId не может быть Guid.Empty.", nameof(locationId));

        Id = Guid.CreateVersion7();
        DepartmentId = departmentId;
        LocationId = locationId;
        IsPrimary = isPrimary;
    }

    public Guid Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }
    public bool IsPrimary { get; private set; }
}