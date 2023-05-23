using SimpraApi.Base.Data;

namespace SimpraApi.Base;
public abstract class EntityCreateCommandHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResult>
    where TEntity : BaseEntity
    where TRequest : EntityCreateCommandRequest
    where TResponse : EntityResponse
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    public EntityCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }
    public async virtual Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(request);
        await _repository.AddAsync(entity);

        return (await _unitOfWork.SaveChangesAsync(cancellationToken) ??
            new SuccessDataResult<EntityResponse>(_mapper.Map<TResponse>(entity), Messages.AddSuccess.Format(nameof(TEntity)), HttpStatusCode.Created));
    }
}
