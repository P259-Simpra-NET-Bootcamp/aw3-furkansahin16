namespace SimpraApi.Base;
public abstract class DeleteCommandHandler<TEntity, TRequest> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResult>
    where TEntity : BaseEntity
    where TRequest : DeleteCommandRequest
{
    protected readonly IRepository<TEntity> _repository;

    protected DeleteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _repository = base._unitOfWork.GetRepository<TEntity>();
    }

    public async virtual Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out TEntity? entity, out IResult? result))
        {
            await _repository.DeleteAsync(entity!);
            result = (await _unitOfWork.SaveChangesAsync()) ??
                new SuccessResult(Messages.DeleteSuccess.Format(nameof(TEntity)), HttpStatusCode.OK);
        }
        return result!;
    }
}
