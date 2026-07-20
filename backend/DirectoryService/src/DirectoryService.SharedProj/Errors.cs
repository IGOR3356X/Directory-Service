namespace DirectoryService.SharedProj;

public record class Errors
{
    public string Code { get;}
    public string Message { get;}
    public ErrorType Type { get;}
    public string? InvalidError { get;}

    private Errors(string code, string message, ErrorType type, string? invalidError = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidError = invalidError;
    }

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
    Validation,
    NotFound,
    Failure,
    Conflict,
}