using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.Department.Exceptions;
#pragma warning disable CA1032,RCS1194
public class DepartmentBadRequestException(Errors[] errors) :BadRequestException(errors);