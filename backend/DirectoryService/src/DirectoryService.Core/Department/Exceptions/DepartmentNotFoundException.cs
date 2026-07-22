using DirectoryService.Core.BaseExceptions;
using DirectoryService.Core.Error;

namespace DirectoryService.Core.Department.Exceptions;

#pragma warning disable CA1032,RCS1194
public class DepartmentNotFoundException() : NotFoundException([Failure.DepartmentErrors.NotFound()]);