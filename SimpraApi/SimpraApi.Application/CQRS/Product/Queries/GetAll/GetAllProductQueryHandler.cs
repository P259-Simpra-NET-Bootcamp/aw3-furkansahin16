namespace SimpraApi.Application;

public class GetAllProductQueryHandler : GetAllQueryHandler<Product, GetAllProductQueryRequest, ProductDto>
{
    public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
