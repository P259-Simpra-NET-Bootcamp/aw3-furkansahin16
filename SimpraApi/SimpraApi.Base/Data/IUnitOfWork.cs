namespace SimpraApi.Base;
public interface IUnitOfWork
{
    Task<IResponse?> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IResponse?> SaveChangesAsyncWithTransaction(CancellationToken cancellationToken = default);
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
}
