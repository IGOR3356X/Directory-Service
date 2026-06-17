namespace DirectoryService.Domain.ValueObjects;

public sealed record Name
{
    private const int MinLength = 3;
    private const int MaxLength = 25;

    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Name FromDb(string value)
    {
        return new Name(value);
    }

    public static Name Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя не может быть пустым.", nameof(name));
        name = name.Trim();
        if (name.Length < MinLength || name.Length > MaxLength)
            throw new ArgumentException("Имя должно быть не менее 3-х символов и не более 255", nameof(name));

        return new Name(name);
    }
}