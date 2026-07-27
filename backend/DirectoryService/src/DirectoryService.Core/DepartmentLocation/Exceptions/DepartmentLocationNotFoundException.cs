using DirectoryService.Core.BaseExceptions;
using DirectoryService.Core.ErrorMapping;

namespace DirectoryService.Core.DepartmentLocation.Exceptions;

#pragma warning disable CA1032,RCS1194
public class DepartmentLocationNotFoundException() : NotFoundException([Failure.DepartmentLocationErrors.NotFoundError()]);