
namespace SimpraApi.Base;
public abstract class EntityHandler<TEntity> where TEntity : BaseEntity
{
    protected readonly IUnitOfWork _unitOfWork;
    public EntityHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    protected bool TryToGetById(int id, out TEntity? entity, out IResult? result)
    {
        entity = _unitOfWork.GetRepository<TEntity>().Find(id, Includes);
        result = entity is null ?
            new ErrorResult(Messages.GetError.Format(nameof(TEntity),id.ToString()), HttpStatusCode.NotFound) :
            null;
        return entity is not null;
    }
    public Expression<Func<TEntity, object>>[]? Includes { get; protected set; }
}
