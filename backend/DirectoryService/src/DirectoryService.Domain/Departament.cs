namespace DirectoryService.Domain;

public class Departament
{
    public Departament(string name, string slug, string path, Guid parentId, bool isActive)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Slug = slug;
        Path = path;
        ParentId = parentId;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public string Path { get; private set; }
    public Guid? ParentId { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}