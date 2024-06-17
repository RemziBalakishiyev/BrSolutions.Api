namespace BrSolution.Application.Wrappers;

public class PagedDataWrapper<T>
{
    public IEnumerable<T> Data { get; set; } = Array.Empty<T>();

    public int Count { get; set; }

    public PagedDataWrapper<TData> PagedTo<TData>(IEnumerable<TData> data)
    {
        return new PagedDataWrapper<TData>
        {
            Count = Count,
            Data = data
        };
    }
}
