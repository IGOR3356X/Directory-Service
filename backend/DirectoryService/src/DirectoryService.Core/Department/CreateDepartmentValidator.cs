using DirectoryService.Contracts;
using FluentValidation;

namespace DirectoryService.Core.Department;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentDto>
{
    public CreateDepartmentValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("Название подразделения не может быть пустым")
            .MinimumLength(3).WithMessage("Название подразделения должно быть не короче 3 символов")
            .MaximumLength(255).WithMessage("Название подразделения должно быть не длиннее 255 символов");
        RuleFor(x => x.Slug)
            .NotNull().NotEmpty().WithMessage("Slug не может быть пустым");
    }
}