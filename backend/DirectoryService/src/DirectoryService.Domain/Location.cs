namespace DirectoryService.Domain;

public class Location
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Timezone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}
