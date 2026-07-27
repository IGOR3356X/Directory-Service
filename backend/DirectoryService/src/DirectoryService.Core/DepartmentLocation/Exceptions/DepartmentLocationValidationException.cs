using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.DepartmentLocation.Exceptions;

#pragma warning disable CA1032
public class DepartmentLocationValidationException: ValidationException
{
    public DepartmentLocationValidationException(Errors[] errors) : base(errors)
    {
    }
}