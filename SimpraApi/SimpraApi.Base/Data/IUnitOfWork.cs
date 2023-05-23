namespace SimpraApi.Base.Data;
public interface IUnitOfWork
{
    Task<IResult?> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IResult?> SaveChangesAsyncWithTransaction(CancellationToken cancellationToken = default);
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
}
