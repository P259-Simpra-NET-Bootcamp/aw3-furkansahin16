namespace SimpraApi.Application;

public class UpdateProductCommandHandler : UpdateCommandHandler<Product, UpdateProductCommandRequest, ProductDto>
{
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public async override Task<IResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out IResponse? response) &&
            await Repository.AnyAsync(x => x.Name == request.Name.NormalizeString(), true) &&
            !String.Equals(Entity!.Name, request.Name, StringComparison.OrdinalIgnoreCase))
        {
            return new ErrorResponse(Messages.UniqueFieldError.Format("Name", request.Name), HttpStatusCode.Forbidden);
        }
        if (Entity is not null &&
            Entity!.CategoryId != request.CategoryId &&
            (await UnitOfWork.GetRepository<Category>().GetAsync(x => x.Id == request.CategoryId) is null))
        {
            return new ErrorResponse(Messages.GetError.Format(nameof(Category), request.CategoryId.ToString()), HttpStatusCode.NotFound);
        }
        return await base.Handle(request, cancellationToken);
    }
}
