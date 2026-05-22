namespace DirectoryService.Domain;

public sealed record Path
{
    public string Value { get; }
    private Path(string path) => Value = path;

    public static Path CreateRoot(Slug slug) => new(slug.Value);

    public static Path CreateChild(Path parentPath, Slug slug)
    {
        ArgumentNullException.ThrowIfNull(parentPath);
        ArgumentNullException.ThrowIfNull(slug);
        return new($"{parentPath.Value}.{slug.Value}");
    }
}