using DirectoryService.Contracts;
using DirectoryService.Core.DepartmentLocation;
using DirectoryService.Core.Location;
using FluentValidation;

namespace DirectoryService.Core.Department;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repositoryDepartment;
    private readonly ILocationRepository _locationRepository;
    private readonly IDepartmentLocationRepository _departmentLocationRepository;
    private readonly IValidator<CreateDepartmentDto> _validator;

    public DepartmentService(IDepartmentRepository repositoryDepartment,
        IValidator<CreateDepartmentDto> validator,
        IDepartmentLocationRepository departmentLocationRepository, ILocationRepository locationRepository)
    {
        _repositoryDepartment = repositoryDepartment;
        _validator = validator;
        _departmentLocationRepository = departmentLocationRepository;
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
            await _departmentLocationRepository.CreateWithLocations(model.Id, locationIds, ct);
        }

        await _repositoryDepartment.Save(ct);

        return model.Id;
    }

    public async Task<Guid> GetById(Guid id, CancellationToken ct)
    {
        var depId = await _repositoryDepartment.GetDepartmentById(id, ct);
        return depId?.Id ?? throw new KeyNotFoundException("Департамента с таким Id не найдено");
    }

    public async Task PartUpdate(Guid id,PartUpdateDepartmentDto request, CancellationToken ct)
    {
        var department = await _repositoryDepartment.GetDepartmentById(id, ct);
        if (department == null)
            throw new KeyNotFoundException("Департамента с таким Id не найдено");
        department.Update(request.Name,request.Slug,request.IsActive);

        await _repositoryDepartment.Save(ct);
    }
}