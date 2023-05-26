namespace SimpraApi.Base;
public abstract class GetByIdQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : GetByIdQueryRequest
    where TResponse : EntityResponse
{
    protected readonly IMapper _mapper;
    public GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork) => _mapper = mapper;
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out IResponse? response))
        {
            response = new SuccessDataResponse<EntityResponse>(_mapper.Map<TResponse>(Entity),Messages.GetSuccess.Format(typeof(TEntity).Name),HttpStatusCode.OK);
        }
        return await Task.FromResult(response!);
    }
}
