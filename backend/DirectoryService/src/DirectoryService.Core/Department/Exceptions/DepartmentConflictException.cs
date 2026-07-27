using DirectoryService.Core.BaseExceptions;
using DirectoryService.Core.ErrorMapping;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.Department.Exceptions;
#pragma warning disable CA1032,RCS1194
public class DepartmentConflictException() : ConflictException([Failure.DepartmentErrors.ConflictError()]);