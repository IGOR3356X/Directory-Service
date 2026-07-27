using DirectoryService.SharedProj;
using FluentValidation.Results;

namespace DirectoryService.Core.Extensions;

public static class ValidationResultExtension
{
    public static Errors[] ToValidationErrors(this ValidationResult validationResult)
    {
        Errors[] failures = validationResult.Errors
            .Select(x=> Errors.Validation(x.ErrorCode,x.ErrorMessage,x.PropertyName)).ToArray();
        return failures;
    }
}