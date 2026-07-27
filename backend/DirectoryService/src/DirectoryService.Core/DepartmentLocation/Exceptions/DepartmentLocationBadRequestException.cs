using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.DepartmentLocation.Exceptions;
#pragma warning disable CA1032,RCS1194
public class DepartmentLocationBadRequestException(Errors[] errors) :BadRequestException(errors);