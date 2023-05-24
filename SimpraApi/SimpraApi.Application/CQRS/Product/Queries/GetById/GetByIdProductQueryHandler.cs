namespace SimpraApi.Application;

public class GetByIdProductQueryHandler : GetByIdQueryHandler<Product, GetByIdProductQueryRequest, ProductDto>
{
    public GetByIdProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        => Includes = new Expression<Func<Product, object>>[]
        {
            x=>x.Category
        };
}
