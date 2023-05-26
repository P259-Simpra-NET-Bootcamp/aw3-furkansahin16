namespace SimpraApi.Base;
public abstract class DeleteCommandHandler<TEntity, TRequest> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : DeleteCommandRequest
{
    protected DeleteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out IResponse? result))
        {
            await Repository.DeleteAsync(Entity!);
            result = (await UnitOfWork.SaveChangesAsync()) ??
                new SuccessResponse(Messages.DeleteSuccess.Format(typeof(TEntity).Name), HttpStatusCode.OK);
        }
        return result!;
    }
}
