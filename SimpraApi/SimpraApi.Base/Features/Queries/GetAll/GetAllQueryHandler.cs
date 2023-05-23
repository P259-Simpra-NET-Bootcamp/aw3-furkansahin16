using SimpraApi.Base.Data;

namespace SimpraApi.Base;
public abstract class GetAllQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResult>
    where TEntity : BaseEntity
    where TRequest : GetAllQueryRequest
    where TResponse : EntityResponse
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }
    public async virtual Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entites = await _repository.GetAllAsync(false);

        return entites.Any() ?
            new SuccessDataResult<EntityResponse>(_mapper.Map<List<TResponse>>(entites),Messages.ListSuccess.Format(nameof(TEntity)),HttpStatusCode.OK) :
            new ErrorResult(Messages.ListError.Format(nameof(TEntity)),HttpStatusCode.NoContent);
    }
}