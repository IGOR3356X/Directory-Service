using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.Department.Exceptions;

#pragma warning disable CA1032
public class DepartmentValidationException: ValidationException
{
    public DepartmentValidationException(Errors[] errors) : base(errors)
    {
    }
}