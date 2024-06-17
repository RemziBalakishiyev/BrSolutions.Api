using BrSolution.Application.Extensions;
using BrSolution.Application.Repositories;
using BrSolution.Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories
{
    public abstract class EfRepository<T> : IRepository<T>
    where T : class, new()
    {
        protected EfRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            Entities = GetQueryableEntity();
        }

        private DbContext DbContext { get; }

        protected IQueryable<T> Entities { get; set; }

        public virtual async Task Add(T entity)
        {
            await DbContext.AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            DbContext.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            DbContext.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            DbContext.UpdateRange(entities);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            DbContext.RemoveRange(entities);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await TryToGetAsync(predicate);
            return entity;
        }

        public virtual async Task<T?> TryToGetAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await Entities.FirstOrDefaultAsync(predicate);

            return entity;
        }

        public virtual async Task<PagedDataWrapper<T>> GetAllAsync(PaginationWrapper pagination, Expression<Func<T, bool>>? predicate = null)
        {
            var queryable = ImplementPredicate(Entities, predicate);

            return await queryable.ToPagedDataAsync(pagination);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            return await ImplementPredicate(Entities, predicate).ToListAsync();
        }

        public async Task<IReadOnlyCollection<TTransformedType>> GetAllAsync<TTransformedType>(
            Expression<Func<T, TTransformedType>> transformTo,
            Expression<Func<T, bool>>? predicate = null)
        {
            return await ImplementPredicate(Entities, predicate).Select(transformTo).ToListAsync();
        }

        public virtual async Task<IDictionary<TKey, T>> GetAllAsDictionaryAsync<TKey>(Func<T, TKey> keySelector, Expression<Func<T, bool>>? predicate = null)
            where TKey : notnull
        {
            var queryable = ImplementPredicate(Entities, predicate);
            var data = await queryable.ToDictionaryAsync(keySelector);

            return data;
        }

        /// <summary>
        /// Use when queryable entity is changed. Reset queryable field when action is done. For example using joins or predicates. Use in <code>try/finally</code> block.
        /// </summary>
        protected virtual void InitQueryableEntity()
        {
            Entities = GetQueryableEntity();
        }

        private IQueryable<T> GetQueryableEntity() => DbContext.Set<T>();

        private static IQueryable<T> ImplementPredicate(
            IQueryable<T> entities,
            Expression<Func<T, bool>>? predicate = null)
            => predicate is not null ? entities.Where(predicate) : entities;

      
    }
}
