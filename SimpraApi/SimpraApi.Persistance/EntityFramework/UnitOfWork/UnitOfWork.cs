namespace SimpraApi.Persistance.EntityFramework;
public class UnitOfWork : IUnitOfWork
{
    private readonly SimpraDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private bool _disposed;
    public UnitOfWork(SimpraDbContext context)
    {
        _context = context;
    }
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
    {
        var entityType = typeof(TEntity);
        if (!_repositories.ContainsKey(entityType))
        {
            var repositoryType = typeof(EfRepository<>).MakeGenericType(entityType);
            var instance = Activator.CreateInstance(repositoryType, _context);
            _repositories.Add(entityType, instance!);
        }
        return (IRepository<TEntity>)_repositories[entityType];
    }

    public async Task<IResult?> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return null;
        }
        catch (Exception ex)
        {
            return GetErrorResult(ex, Messages.DbError);
        }
        finally { this.Dispose(); }
    }

    public async Task<IResult?> SaveChangesAsyncWithTransaction(CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        IResult? result = null;
        await strategy.ExecuteAsync(async () =>
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                result = GetErrorResult(ex, Messages.DbTransactionError);
            }
            finally { this.Dispose(); }
        });
        return result;
    }
    public void Dispose() => Clean(true);
    private IResult GetErrorResult(Exception ex, string message)
    {
        return new ErrorDataResult<Object>(ex.Data, message, HttpStatusCode.InternalServerError)
        {
            Errors = new()
            {
                $"Message: {ex.Message}",
                $"Help Link: {ex.HelpLink}",
                $"Source: {ex.Source}",
                $"Inner Exception: {ex.InnerException?.Message}"
            }
        };
    }
    private void Clean(bool disposing)
    {
        if (!_disposed && disposing) _context.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}