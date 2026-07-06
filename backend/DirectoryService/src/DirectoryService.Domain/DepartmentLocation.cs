namespace DirectoryService.Domain;

public sealed class DepartmentLocation
{
    private DepartmentLocation()
    {
    }

    private DepartmentLocation(Guid departmentId, Guid locationId, bool isPrimary)
    {
        Id = Guid.CreateVersion7();
        DepartmentId = departmentId;
        LocationId = locationId;
        IsPrimary = isPrimary;
    }

    public Guid Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid LocationId { get; private set; }
    public bool IsPrimary { get; private set; }

    public static DepartmentLocation Create(Guid departmentId, Guid locationId, bool isPrimary)
    {
        if (Guid.Empty == departmentId)
            throw new ArgumentException("departmentId не может быть Guid.Empty.", nameof(departmentId));
        if (Guid.Empty == locationId)
            throw new ArgumentException("locationId не может быть  Guid.Empty.", nameof(locationId));

        return new DepartmentLocation(departmentId, locationId, isPrimary);
    }
}