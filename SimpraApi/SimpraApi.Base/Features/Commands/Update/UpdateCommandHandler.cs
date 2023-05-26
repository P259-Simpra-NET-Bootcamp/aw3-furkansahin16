namespace SimpraApi.Base;
public abstract class UpdateCommandHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : UpdateCommandRequest
    where TResponse : EntityResponse
{
    protected readonly IMapper _mapper;
    public UpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork) => _mapper = mapper;
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (Entity is not null || TryToGetById(request.Id, out IResponse? response))
        {
            var updatedModel = _mapper.Map(request, Entity);

            response = (await UnitOfWork.SaveChangesAsync(cancellationToken)) ??
                new SuccessDataResponse<EntityResponse>(_mapper.Map<TResponse>(updatedModel), Messages.UpdateSuccess.Format(typeof(TEntity).Name), HttpStatusCode.Accepted);
        }
        return response!;
    }
}
