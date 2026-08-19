using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DirectoryService.SharedProj;

public record Errors
{
    public string Code { get;}
    public string Message { get;}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get;}
    public string? InvalidField { get;}
    
    [JsonConstructor]
    private Errors(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }
    
    public static Errors None() => 
        new("","",ErrorType.None, null);
    public static Errors NotFound(string? code,string message)
        => new(code ?? "record.not.found", message,ErrorType.NotFound);

    public static Errors Validation(string? code, string message, string? validationField = null) =>
        new(code ?? "value.validation.error", message,ErrorType.Validation ,validationField);

    public static Errors Conflict(string? code, string message) =>
        new(code ?? "record.conflict", message, ErrorType.Conflict);

    public static Errors Failure(string? code, string message) =>
        new(code ?? "value.failure", message, ErrorType.Failure);
}

public enum ErrorType
{
    [Description("Ошибка валидации")]
    Validation,
    [Description("Ошибка объект не найден")]
    NotFound,
    [Description("Фаталочка")]
    Failure,
    [Description("Конфликт")]
    Conflict,
    [Description("Нет ошибки")]
    None
}