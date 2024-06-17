using BrSolution.Application.Wrappers;
using System.Linq.Expressions;

namespace BrSolution.Application.Repositories;

public interface IRepository<T>
     where T : class, new()
{
    Task Add(T entity);

    void AddRange(IEnumerable<T> entities);

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);

    void Delete(T entity);

    void DeleteRange(IEnumerable<T> entities);

    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<PagedDataWrapper<T>> GetAllAsync(PaginationWrapper pagination, Expression<Func<T, bool>>? predicate = null);

    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);

    Task<IReadOnlyCollection<TTransformedType>> GetAllAsync<TTransformedType>(
        Expression<Func<T, TTransformedType>> transformTo,
        Expression<Func<T, bool>>? predicate = null);

    Task<IDictionary<TKey, T>> GetAllAsDictionaryAsync<TKey>(Func<T, TKey> keySelector, Expression<Func<T, bool>>? predicate = null)
        where TKey : notnull;
}
