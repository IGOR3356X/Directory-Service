using DirectoryService.Core.Exceptions;
using DirectoryService.Shared;

namespace DirectoryService.Core.Department.Exceptions;

#pragma warning disable CA1032
public class DepartmentValidationException: BadRequestException
#pragma warning restore CA1032
{
    public DepartmentValidationException(Errors[] errors) : base(errors)
    {
    }
}