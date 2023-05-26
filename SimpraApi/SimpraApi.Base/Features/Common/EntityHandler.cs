
namespace SimpraApi.Base;
public abstract class EntityHandler<TEntity> where TEntity : BaseEntity
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly IUnitOfWork UnitOfWork;
    public EntityHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        Repository = UnitOfWork.GetRepository<TEntity>();
    }
    protected bool TryToGetById(int id, out IResponse? response)
    {
        Entity = Repository.Find(id, Includes);
        response = Entity is null ?
            new ErrorResponse(Messages.GetError.Format(typeof(TEntity).Name,id.ToString()), HttpStatusCode.NotFound) :
            null;
        return Entity is not null;
    }
    public Expression<Func<TEntity, object>>[]? Includes { get; protected set; }
    public TEntity? Entity { get; protected set; }
}
