namespace SimpraApi.Base;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task DeleteAsync(TEntity entity);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params Expression<Func<TEntity, object>>[]? includes);
    TEntity? Find(object key, params Expression<Func<TEntity, object>>[]? includes);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool includesDeleted = false);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true, params Expression<Func<TEntity, object>>[]? includes);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true, params Expression<Func<TEntity, object>>[]? includes);
}