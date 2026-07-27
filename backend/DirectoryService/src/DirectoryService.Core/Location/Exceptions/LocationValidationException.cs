using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.Location.Exceptions;

#pragma warning disable CA1032
public class LocationValidationException: ValidationException
{
    public LocationValidationException(Errors[] errors) : base(errors)
    {
    }
}