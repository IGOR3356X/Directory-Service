using DirectoryService.Contracts;
using FluentValidation;

namespace DirectoryService.Core.Location;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IValidator<CreateLocationDto> _validator;

    public LocationService(ILocationRepository locationRepository, IValidator<CreateLocationDto> validator)
    {
        _locationRepository = locationRepository;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateLocationDto request, CancellationToken ct)
    {
        var validationResult = await _validator.ValidateAsync(request, ct);
        if(!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var isNameExists = await _locationRepository.IsNameExists(request.Name,ct);
        if (isNameExists)
        {
            throw new InvalidOperationException("Имя этой локации уже существует");
        }

        var location = new Domain.Location(
            name: request.Name,
            city: request.City,
            street: request.Street,
            houseNumber: request.HouseNumber,
            isActive: request.IsActive);

        var locationId = await  _locationRepository.Create(location, ct);

        return locationId;
    }
}