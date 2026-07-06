using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain;

public sealed class Location
{
    private Location()
    {
    }

    private Location(Name name, Address address, bool isActive)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Address = address;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }
    public Name Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public static Location Create(string name, string city, string street, string houseNumber, bool isActive)
    {
        return new Location(Name.Create(name),ValueObjects.Address.Create(city, street, houseNumber), isActive);
    }

    public static void Update()
}