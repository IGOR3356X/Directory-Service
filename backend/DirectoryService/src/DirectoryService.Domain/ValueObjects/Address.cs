namespace DirectoryService.Domain;

public sealed record Address
{
    public string Value { get; }
    private Address(string value) => Value = value;
    
    public static Address FromDb(string value) => new(value);

    public static Address Create(string city, string street, string houseNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Город не может быть пустым.", nameof(city));
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Улица не может быть пустой.", nameof(street));
        if (string.IsNullOrWhiteSpace(houseNumber))
            throw new ArgumentException("Номер дома не может быть пустым.", nameof(houseNumber));
        city = city.Trim();
        street = street.Trim();
        houseNumber = houseNumber.Trim();
        string normalized = $"{city}, {street}, {houseNumber}";
        return new Address(normalized);
    }
}