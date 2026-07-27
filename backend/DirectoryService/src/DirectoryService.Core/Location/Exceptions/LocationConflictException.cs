using DirectoryService.Core.BaseExceptions;
using DirectoryService.Core.ErrorMapping;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.Location.Exceptions;
#pragma warning disable CA1032,RCS1194
public class LocationConflictException() : ConflictException([Failure.LocationErrors.ConflictError()]);