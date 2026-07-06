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
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var isNameExists = await _locationRepository.IsNameExists(request.Name, ct);
        if (isNameExists) throw new InvalidOperationException("Имя этой локации уже существует");

        var locationId = await _locationRepository.Create(
            Domain.Location.Create(request.Name,
            request.City,
            request.Street,
            request.HouseNumber,
            request.IsActive), ct);

        await _locationRepository.Save(ct);

        return locationId;
    }

    public async Task PartUpdate(Guid id, PartUpdateLocationDto request, CancellationToken ct)
    {
        var location = await _locationRepository.GetById(id, ct) ?? throw new KeyNotFoundException("Локации с таким id не существует");

        location.Update(request.Name, request.City, request.Street, request.HouseNumber, request.IsActive);

        await _locationRepository.Save(ct);
    }
}