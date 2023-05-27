using System.Linq.Expressions;

namespace SimpraApi.Persistance.EntityFramework;
public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _table;
    public EfRepository(DbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    #region Command
    public async Task DeleteAsync(TEntity entity) => await Task.FromResult(_table.Remove(entity));
    public async Task UpdateAsync(TEntity entity) => await Task.FromResult(_table.Update(entity));
    public async Task AddAsync(TEntity entity) => await _table.AddAsync(entity);
    #endregion

    #region Query
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null)
        => filter is null ? await GetAllActives(false).AnyAsync() : await GetAllActives(false).AnyAsync(filter);
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, bool includesDeleted = false)
        => includesDeleted ? await _table.AsNoTracking().AnyAsync(filter) : await GetAllActives(true).AnyAsync(filter);
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params Expression<Func<TEntity, object>>[]? includes)
        => await GetAllActives(tracking, includes).FirstOrDefaultAsync(expression);
    public TEntity? Find(object key, params Expression<Func<TEntity, object>>[]? includes)
        => GetAllActives(true, includes).FirstOrDefault(x => x.Id == (int)key);
    public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true, params Expression<Func<TEntity, object>>[]? includes)
    => await GetAllActives(tracking, includes).ToListAsync();
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true, params Expression<Func<TEntity, object>>[]? includes)
        => await GetAllActives(tracking, includes).Where(filter).ToListAsync();
    #endregion

    private IQueryable<TEntity> GetAllActives(bool tracking = true, params Expression<Func<TEntity, object>>[]? includes)
    {
        var entites = includes is not null && includes.Any()
            ? _table.Where(x => x.Status != Status.Deleted).Includes(includes)
            : _table.Where(x => x.Status != Status.Deleted);
        return tracking ? entites : entites.AsNoTracking();
    }
}