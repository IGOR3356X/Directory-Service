using DirectoryService.Contracts;
using DirectoryService.Core.DepartmentLocation;
using DirectoryService.Core.Location;
using FluentValidation;

namespace DirectoryService.Core.Department;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repositoryDepartment;
    private readonly ILocationRepository _locationRepository;
    private readonly IDepartmentLocationRepository _repositoryDepartmentLocationRepository;
    private readonly IValidator<CreateDepartmentDto> _validator;

    public DepartmentService(IDepartmentRepository repositoryDepartment,
        IValidator<CreateDepartmentDto> validator,
        IDepartmentLocationRepository repositoryDepartmentLocationRepository, ILocationRepository locationRepository)
    {
        _repositoryDepartment = repositoryDepartment;
        _validator = validator;
        _repositoryDepartmentLocationRepository = repositoryDepartmentLocationRepository;
        _locationRepository = locationRepository;
    }

    public async Task<Guid> Create(CreateDepartmentDto request, CancellationToken ct)
    {
        var validationResult = await _validator.ValidateAsync(request, ct);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var parent = request.ParentId.HasValue
            ? await _repositoryDepartment.GetDepartmentById(request.ParentId.Value, ct)
            : null;

        var model = Domain.Department.Create(request.Name, request.Slug, request.ParentId, parent?.Path.Value,
            request.IsActive);

        await _repositoryDepartment.CreateDepartment(model, ct);

        var locationIds = request.LocationIds?.Distinct().ToList() ?? [];

        if (locationIds.Count > 0)
        {
            var isExist = await _locationRepository.IsLocationExists(locationIds, ct);
            if (!isExist)
            {
                throw new KeyNotFoundException("Одна или несколько локаций не существуют");
            }
            await _repositoryDepartmentLocationRepository.CreateDepartmentLocation(model.Id, locationIds, ct);
        }

        await _repositoryDepartment.Save(ct);
        
        return model.Id;
    }
}