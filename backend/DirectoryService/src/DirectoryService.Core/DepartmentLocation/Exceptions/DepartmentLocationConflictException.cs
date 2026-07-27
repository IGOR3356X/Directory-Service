using DirectoryService.Core.BaseExceptions;
using DirectoryService.Core.ErrorMapping;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.DepartmentLocation.Exceptions;
#pragma warning disable CA1032,RCS1194
public class DepartmentLocationConflictException() : ConflictException([Failure.DepartmentLocationErrors.ConflictError()]);