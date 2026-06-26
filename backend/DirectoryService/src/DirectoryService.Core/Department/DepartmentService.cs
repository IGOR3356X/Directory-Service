using DirectoryService.Contracts;
using FluentValidation;

namespace DirectoryService.Core.Department;

public class DepartmentService: IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly IValidator<CreateDepartmentDto> _validator;
    public DepartmentService(IDepartmentRepository repository, IValidator<CreateDepartmentDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateDepartmentDto request, CancellationToken ct)
    {
        var validationResult = await _validator.ValidateAsync(request, ct);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        if (request.ParentId != null && request.ParentId != Guid.Empty)
        {
            
        }
    }
}