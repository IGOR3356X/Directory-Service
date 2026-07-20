using System.Text.Encodings.Web;
using System.Text.Json;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.BaseExceptions;

#pragma warning disable CA1032, RCS1194, CA1869
public class NotFoundException(Errors[] errors) : Exception(JsonSerializer.Serialize(errors, new JsonSerializerOptions()
{
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
}));