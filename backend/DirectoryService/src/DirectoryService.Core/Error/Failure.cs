using DirectoryService.SharedProj;

namespace DirectoryService.Core.Error;

public static partial class Failure
{
    public static class DepartmentErrors
    {
        public static Errors NotFound() => Errors.NotFound(null,"Департамента с таким Id не найдено");
    }
}