using SimpraApi.Base.Data;

namespace SimpraApi.Base;
public abstract class GetByIdQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResult>
    where TEntity : BaseEntity
    where TRequest : GetByIdQueryRequest
    where TResponse : EntityResponse
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    public GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }
    public async virtual Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out TEntity? entity, out IResult? result))
        {
            result = new SuccessDataResult<EntityResponse>(_mapper.Map<TResponse>(entity),Messages.GetSuccess.Format(nameof(TEntity)),HttpStatusCode.OK);
        }
        return await Task.FromResult(result!);
    }
}
