namespace DirectoryService.Domain.ValueObjects;

public sealed record Path
{
    private Path(string path)
    {
        Value = path;
    }

    public string Value { get; }

    public static Path CreateRoot(Slug slug)
    {
        return new Path(slug.Value);
    }

    public static Path FromDb(string fromDb)
    {
        return new Path(fromDb);
    }

    public static Path CreateChild(string parentPath, Slug slug)
    {
        ArgumentNullException.ThrowIfNull(parentPath);
        ArgumentNullException.ThrowIfNull(slug);
        return new Path($"{parentPath}.{slug.Value}");
    }
}