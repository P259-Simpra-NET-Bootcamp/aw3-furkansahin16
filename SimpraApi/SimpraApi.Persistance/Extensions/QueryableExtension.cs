using System.Linq.Expressions;

namespace SimpraApi.Persistance;
public static class QueryableExtension
{
    public static IQueryable<TEntity> Includes<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
    {
        if (includes.Any())
        {
            query = includes.Aggregate(query, (a, b) => a.Include(b));
        }
        return query;
    }
}
