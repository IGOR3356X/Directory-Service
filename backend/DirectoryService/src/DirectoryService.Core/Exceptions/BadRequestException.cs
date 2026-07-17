using System.Text.Json;
using DirectoryService.Shared;

namespace DirectoryService.Core.Exceptions;

#pragma warning disable RCS1194, CA1032
public class BadRequestException(Errors[] errors) : Exception(JsonSerializer.Serialize(errors));
#pragma warning restore CA1032, RCS1194