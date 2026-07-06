using DirectoryService.Domain.ValueObjects;
using Path = DirectoryService.Domain.ValueObjects.Path;

namespace DirectoryService.Domain;

public sealed class Department
{
    private Department()
    {
    }

    private Department(Name name, Slug slug, Path path, Guid? parentId, bool isActive)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Slug = slug;
        Path = path;
        ParentId = parentId;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }
    public Name Name { get; private set; } = null!;
    public Slug Slug { get; private set; } = null!;
    public Path Path { get; private set; } = null!;
    public Guid? ParentId { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public static Department Create(string name, string slug, Guid? parentId, string? parentPath, bool isActive)
    {
        if (parentId is null && parentPath is not null)
            throw new ArgumentException("У корня не должно быть parentPath.", nameof(parentPath));

        if (parentId is not null && parentPath is null)
            throw new ArgumentException("Для дочернего подразделения нужен parentPath.", nameof(parentPath));

        if (parentId == Guid.Empty)
            throw new ArgumentException("ParentId не может быть Guid.Empty.", nameof(parentId));

        var departmentName = Name.Create(name);
        var departmentSlug = Slug.Create(slug);

        var path = string.IsNullOrWhiteSpace(parentPath)
            ? Path.CreateRoot(departmentSlug)
            : Path.CreateChild(parentPath, departmentSlug);

        return new Department(departmentName, departmentSlug, path, parentId, isActive);
    }

    public void Update(string name, string slug,bool isActive)
    {
        Name = Name.Create(name);
        Slug = Slug.Create(slug);
        IsActive = isActive;
        UpdatedAt = DateTime.UtcNow;
    }
}