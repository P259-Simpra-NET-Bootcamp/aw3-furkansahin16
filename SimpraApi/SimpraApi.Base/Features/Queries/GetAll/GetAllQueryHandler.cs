namespace SimpraApi.Base;
public abstract class GetAllQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : GetAllQueryRequest
    where TResponse : EntityResponse
{
    protected readonly IMapper _mapper;
    public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork) => _mapper = mapper;
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var entites = await Repository.GetAllAsync(false, Includes);

        return entites.Any() ?
            new SuccessDataResponse<EntityResponse>(_mapper.Map<List<TResponse>>(entites),Messages.ListSuccess.Format(typeof(TEntity).Name),HttpStatusCode.OK) :
            new ErrorResponse(Messages.ListError.Format(typeof(TEntity).Name),HttpStatusCode.NoContent);
    }
}