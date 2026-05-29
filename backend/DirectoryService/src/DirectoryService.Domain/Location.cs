namespace DirectoryService.Domain;

public sealed class Location
{
    private Location(){}
    public Location(string name, string city,string street, string houseNumber, bool isActive)
    {
        Id = Guid.CreateVersion7();
        Name = Name.Create(name);
        Address = Address.Create(city, street, houseNumber);
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }
    public Name Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}