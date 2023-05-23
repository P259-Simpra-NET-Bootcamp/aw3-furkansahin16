namespace SimpraApi.Base;
public abstract class UpdateCommandHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResult>
    where TEntity : BaseEntity
    where TRequest : UpdateCommandRequest
    where TResponse : EntityResponse
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    public UpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }
    public async virtual Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out TEntity? entity, out IResult? result))
        {
            var updatedModel = _mapper.Map(result, entity);

            result = (await _unitOfWork.SaveChangesAsync(cancellationToken)) ??
                new SuccessDataResult<EntityResponse>(_mapper.Map<TResponse>(updatedModel), Messages.UpdateSuccess.Format(nameof(TEntity)), HttpStatusCode.Accepted);
        }
        return result!;
    }
}
