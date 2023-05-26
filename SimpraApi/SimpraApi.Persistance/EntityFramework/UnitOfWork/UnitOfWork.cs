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

    public async Task<IResponse?> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return null;
        }
        catch (Exception ex)
        {
            return GetErrorResponse(ex, Messages.DbError);
        }
        finally { this.Dispose(); }
    }

    public async Task<IResponse?> SaveChangesAsyncWithTransaction(CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        IResponse? response = null;
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
                response = GetErrorResponse(ex, Messages.DbTransactionError);
            }
            finally { this.Dispose(); }
        });
        return response;
    }
    public void Dispose() => Clean(true);
    private IResponse GetErrorResponse(Exception ex, string message)
    {
        return new ErrorDataResponse<Object>(ex.Data, message, HttpStatusCode.InternalServerError)
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