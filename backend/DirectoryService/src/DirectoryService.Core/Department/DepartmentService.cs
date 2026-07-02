using DirectoryService.Contracts;
using DirectoryService.Core.DepartmentLocation;
using FluentValidation;

namespace DirectoryService.Core.Department;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repositoryDepartment;
    private readonly IDepartmentLocationRepository _repositoryDepartmentLocationRepository;
    private readonly IValidator<CreateDepartmentDto> _validator;

    public DepartmentService(IDepartmentRepository repositoryDepartment,
        IValidator<CreateDepartmentDto> validator,
        IDepartmentLocationRepository repositoryDepartmentLocationRepository)
    {
        _repositoryDepartment = repositoryDepartment;
        _validator = validator;
        _repositoryDepartmentLocationRepository = repositoryDepartmentLocationRepository;
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
            await _repositoryDepartmentLocationRepository.CreateDepartmentLocation(model.Id, locationIds, ct);


        return model.Id;
    }
}