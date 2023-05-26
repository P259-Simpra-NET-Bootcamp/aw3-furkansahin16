namespace SimpraApi.Application;
public class CreateProductCommandHandler : CreateCommandHandler<Product, CreateProductCommandRequest, ProductDto>
{
    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public async override Task<IResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (await Repository.AnyAsync(x => x.Name == request.Name.NormalizeString(), true))
        {
            return new ErrorResponse(Messages.UniqueFieldError.Format("Name", request.Name), HttpStatusCode.Forbidden);
        }
        return await base.Handle(request, cancellationToken);
    }
}
