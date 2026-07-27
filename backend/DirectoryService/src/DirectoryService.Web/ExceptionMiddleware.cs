using System.Text.Json;
using DirectoryService.Core.BaseExceptions;
using DirectoryService.SharedProj;

namespace DirectoryService.Web;
#pragma warning disable CA1031,CA1848,CA2254
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }

        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        _logger.LogError(exception, exception.Message);

        var (code, errors) = exception switch
        {
            BadRequestException =>
                (StatusCodes.Status400BadRequest, JsonSerializer.Deserialize<Errors[]>(exception.Message)),
            ConflictException =>
                (StatusCodes.Status409Conflict, JsonSerializer.Deserialize<Errors[]>(exception.Message)),
            NotFoundException =>
                (StatusCodes.Status404NotFound, JsonSerializer.Deserialize<Errors[]>(exception.Message)),
            ValidationException =>
                (StatusCodes.Status400BadRequest, JsonSerializer.Deserialize<Errors[]>(exception.Message)),

            _ => (StatusCodes.Status500InternalServerError, [Errors.Failure(null,"Что-то пошло не так")])
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = code;

        await httpContext.Response.WriteAsJsonAsync(errors);
    }
}