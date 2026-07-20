using System.Text.Encodings.Web;
using System.Text.Json;
using DirectoryService.SharedProj;

namespace DirectoryService.Core.BaseExceptions;

#pragma warning disable RCS1194, CA1032, CA1869
public class BadRequestException(Errors[] errors) : Exception(JsonSerializer.Serialize(errors,new JsonSerializerOptions()
{
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
}));