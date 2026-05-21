namespace DirectoryService.Domain;

public sealed record Slug
{
    public string Value { get; }

    private Slug(string value) => Value = value;

    public static Slug Create(string value)
    {
        string normalized = value.Trim().ToLowerInvariant();
        return new Slug(normalized);
    }
}