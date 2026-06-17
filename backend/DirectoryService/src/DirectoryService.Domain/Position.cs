using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain;

public sealed class Position
{
    private Position()
    {
    }

    public Position(string name, string description, bool isActive)
    {
        Id = Guid.CreateVersion7();
        Name = Name.Create(name);
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Описание не может быть пустым.", nameof(description));
        Description = description.Trim();
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }
    public Name Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }
}