namespace DirectoryService.Domain;

public sealed class DepartmentPosition
{
    public DepartmentPosition(Guid departmentId, Guid positionId)
    {
        if (Guid.Empty == departmentId) throw new ArgumentException("departmentId не может быть Guid.Empty.",nameof(departmentId));
        if (Guid.Empty == positionId) throw new ArgumentException("positionId не может быть Guid.Empty.",nameof(positionId));
        
        Id = Guid.CreateVersion7();
        DepartmentId = departmentId;
        PositionId = positionId;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Guid PositionId { get; private set; }
    public DateTime CreatedAt { get; private set; }
}