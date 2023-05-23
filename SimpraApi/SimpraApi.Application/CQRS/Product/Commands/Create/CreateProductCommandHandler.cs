namespace SimpraApi.Application;
public class CreateProductCommandHandler : CreateCommandHandler<Product, CreateProductCommandRequest, ProductDto>
{
    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
