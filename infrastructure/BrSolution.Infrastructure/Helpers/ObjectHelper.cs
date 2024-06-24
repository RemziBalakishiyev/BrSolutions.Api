namespace BrSolution.Infrastructure.Helpers;


public static class ObjectHelper
{
    public static bool IsAnyNull(params object?[] values)
             => values.Any(value => value is null);
}
