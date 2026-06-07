using DirectoryService.Contracts;
using FluentValidation;

namespace DirectoryService.Core.Location;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Имя локации не может быть пустым");
        RuleFor(x => x.City).NotNull().NotEmpty().WithMessage("Город не может быть пустым");
        RuleFor(x => x.Street).NotNull().NotEmpty().WithMessage("Улица не может быть пустой");
        RuleFor(x => x.HouseNumber).NotNull().NotEmpty().WithMessage("Дом не может быть пустым");
        RuleFor(x => x.IsActive).NotNull().WithMessage("Указание активного/не активного статуса локации объязательно");
    }
}