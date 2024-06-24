namespace BrSolution.Infrastructure.Extensions;

public static class EnumerableExtension
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var value in source)
        {
            action(value);
        }
    }

    public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
    {
        foreach (var value in source)
        {
            await action(value);
        }
    }
}
