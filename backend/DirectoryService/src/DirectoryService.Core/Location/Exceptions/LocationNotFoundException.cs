using DirectoryService.Core.BaseExceptions;
using DirectoryService.Core.ErrorMapping;

namespace DirectoryService.Core.Location.Exceptions;

#pragma warning disable CA1032,RCS1194
public class LocationNotFoundException() : NotFoundException([Failure.LocationErrors.NotFoundError()]);