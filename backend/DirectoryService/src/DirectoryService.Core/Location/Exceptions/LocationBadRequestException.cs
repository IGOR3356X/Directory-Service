using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.Location.Exceptions;
#pragma warning disable CA1032,RCS1194
public class LocationBadRequestException(Errors[] errors) :BadRequestException(errors);