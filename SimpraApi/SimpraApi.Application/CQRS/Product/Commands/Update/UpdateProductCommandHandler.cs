namespace SimpraApi.Application;

public class UpdateProductCommandHandler : UpdateCommandHandler<Product, UpdateProductCommandRequest, ProductDto>
{
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public async override Task<IResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out IResponse? response) &&
            await Repository.AnyAsync(x => x.Name == request.Name.NormalizeString()) &&
            !String.Equals(Entity!.Name, request.Name, StringComparison.OrdinalIgnoreCase))
        {
            return new ErrorResponse(Messages.UniqueFieldError.Format("Name", request.Name), HttpStatusCode.Forbidden));
        }
        return await base.Handle(request, cancellationToken);
    }
}
