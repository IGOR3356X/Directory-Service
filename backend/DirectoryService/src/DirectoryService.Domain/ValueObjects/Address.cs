namespace DirectoryService.Domain.ValueObjects;

public sealed record Address
{
    private Address(string city, string street, string houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public string City { get; }
    public string Street { get; }
    public string HouseNumber { get; }

    public string Formatted => $"{City}, {Street}, {HouseNumber}";

    public static Address FromDb(string city, string street, string houseNumber)
    {
        return new Address(city, street, houseNumber);
    }

    public static Address Create(string city, string street, string houseNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Город не может быть пустым.", nameof(city));
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Улица не может быть пустой.", nameof(street));
        if (string.IsNullOrWhiteSpace(houseNumber))
            throw new ArgumentException("Номер дома не может быть пустым.", nameof(houseNumber));

        return new Address(
            city.Trim(),
            street.Trim(),
            houseNumber.Trim());
    }
}