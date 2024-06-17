using BrSolution.Application.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace BrSolution.Application.Extensions;

public static class QueryableExtension
{
    public static async Task<PagedDataWrapper<T>> ToPagedDataAsync<T>(this IQueryable<T> queryable, PaginationWrapper pagination)
    {
        var count = await queryable.CountAsync();

        if (count == default)
        {
            return new PagedDataWrapper<T>
            {
                Data = Array.Empty<T>()
            };
        }

        //if (pagination.GetLastPage(count) < pagination.Page)
        //{
        //    throw new IpgCourseManagementException(SystemMessageValue.IncorrectPaginationParameter);
        //}

        return new PagedDataWrapper<T>
        {
            Data = await queryable.ApplyPagination(pagination)
            .ToListAsync(),
            Count = count
        };
    }

    private static IQueryable<T> ApplyPagination<T>(this IQueryable<T> queryable, PaginationWrapper pagination)
        => queryable.Skip(pagination.Count * (pagination.Page - 1))
            .Take(pagination.Count);
}
