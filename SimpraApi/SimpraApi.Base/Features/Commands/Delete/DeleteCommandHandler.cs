namespace SimpraApi.Base;
public abstract class DeleteCommandHandler<TEntity, TRequest> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : DeleteCommandRequest
{
    protected readonly IRepository<TEntity> _repository;

    protected DeleteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _repository = base._unitOfWork.GetRepository<TEntity>();
    }

    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out TEntity? entity, out IResponse? result))
        {
            await _repository.DeleteAsync(entity!);
            result = (await _unitOfWork.SaveChangesAsync()) ??
                new SuccessResponse(Messages.DeleteSuccess.Format(nameof(TEntity)), HttpStatusCode.OK);
        }
        return result!;
    }
}
