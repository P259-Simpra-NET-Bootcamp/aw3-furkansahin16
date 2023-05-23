using System.Linq.Expressions;

namespace SimpraApi.Base.Data;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task DeleteAsync(TEntity entity);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    TEntity? Find(object key, bool tracking = true);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
}