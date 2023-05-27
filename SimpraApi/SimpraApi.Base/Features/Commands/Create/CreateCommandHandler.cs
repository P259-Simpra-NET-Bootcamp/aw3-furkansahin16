namespace SimpraApi.Base;
public abstract class CreateCommandHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : CreateCommandRequest
    where TResponse : EntityResponse
{
    private readonly IMapper _mapper;
    public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork) => _mapper = mapper;
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        Entity = _mapper.Map<TEntity>(request);
        await Repository.AddAsync(_mapper.Map<TEntity>(request));

        return (await UnitOfWork.SaveChangesAsync(cancellationToken) ??
            new SuccessDataResponse<EntityResponse>(_mapper.Map<TResponse>(Entity), Messages.AddSuccess.Format(typeof(TEntity).Name), HttpStatusCode.Created));
    }
}
