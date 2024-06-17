namespace BrSolution.Application.Wrappers;

public class PaginationWrapper
{
    private const int DataLimit = 100;

    private int _page;
    private int _count;

    public int Page
    {
        get => _page;
        set => _page = value < 1 ? 1 : value;
    }

    public int Count
    {
        get => _count;
        set => _count = value < 1 ? 1 : value > DataLimit ? DataLimit : value;
    }

    public int GetLastPage(int count)
        => (int)Math.Ceiling((double)count / Count);
}
