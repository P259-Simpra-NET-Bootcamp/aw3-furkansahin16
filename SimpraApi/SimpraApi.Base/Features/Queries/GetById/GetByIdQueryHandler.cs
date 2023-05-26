namespace SimpraApi.Base;
public abstract class GetByIdQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
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
    public GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, Expression<Func<TEntity) : base(unitOfWork)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out TEntity? entity, out IResponse? response))
        {
            response = new SuccessDataResponse<EntityResponse>(_mapper.Map<TResponse>(entity),Messages.GetSuccess.Format(nameof(TEntity)),HttpStatusCode.OK);
        }
        return await Task.FromResult(response!);
    }
}
