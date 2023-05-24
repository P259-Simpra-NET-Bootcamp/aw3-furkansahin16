namespace SimpraApi.Application;

public class GetWhereProductQueryHandler : GetWhereQueryHandler<Product, GetWhereProductQueryRequest, ProductDto>
{
    public GetWhereProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        => Includes = new Expression<Func<Product, object>>[]
        {
            x=>x.Category
        };
}
