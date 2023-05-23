namespace SimpraApi.Application;

public class UpdateProductCommandHandler : UpdateCommandHandler<Product, UpdateCommandRequest, ProductDto>
{
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
