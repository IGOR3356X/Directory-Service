namespace DirectoryService.Domain;

public sealed record Name
{
    private const int MinLength = 3;
    private const int MaxLength = 255;
    
    public string Value { get; }
    private Name (string value) => Value = value;

    public static Name Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя не может быть пустым.", nameof(name));
        name = name.Trim();
        if (name.Length < MinLength || name.Length > MaxLength)
            throw new ArgumentException("Имя должно быть не менее 3-х символов и не более 255",nameof(name));

        return new Name(name);
    }
}