namespace SimpraApi.Application;

public class GetByIdProductQueryHandler : GetByIdQueryHandler<Product, GetByIdProductQueryRequest, ProductDto>
{
    public GetByIdProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
