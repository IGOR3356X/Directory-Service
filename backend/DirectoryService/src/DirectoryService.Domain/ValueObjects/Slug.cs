using System.Text.RegularExpressions;

namespace DirectoryService.Domain.ValueObjects;

public sealed record Slug
{
    private static readonly Regex SlugRegex = new("^[a-z0-9-]+$", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

    private Slug(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Slug Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Slug не может быть пустым", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (!SlugRegex.IsMatch(normalized))
            throw new ArgumentException(
                "Slug должен содержать только строчные латинские буквы, цифры и дефис.",
                nameof(value));

        return new Slug(normalized);
    }
}