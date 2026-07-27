using DirectoryService.SharedProj;

namespace DirectoryService.Core.ErrorMapping;

public static partial class Failure
{
    public static class DepartmentErrors
    {
        public static Errors NotFoundError() => Errors.NotFound(null,"Департамента с таким Id не найдено");
        public static Errors ConflictError() => Errors.Conflict(null, "Департамент уже существует");
    }
    public static class LocationErrors
    {
        public static Errors NotFoundError() => Errors.NotFound(null,"Локации с таким Id не найдено");
        public static Errors ConflictError() => Errors.Conflict("location.validation.error", "Локация уже существует");
    }
    public static class DepartmentLocationErrors
    {
        public static Errors NotFoundError() => Errors.NotFound(null,"Такой связи локации и депортамента не найдено");
        public static Errors ConflictError() => Errors.Conflict(null, "Такая связь локации и депортамента уже существует");
    }
}