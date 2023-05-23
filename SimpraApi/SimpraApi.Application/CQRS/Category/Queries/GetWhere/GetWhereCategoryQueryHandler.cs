namespace SimpraApi.Application;

public class GetWhereCategoryQueryHandler : GetWhereQueryHandler<Category, GetWhereCategoryQueryRequest, CategoryDetailDto>
{
    public GetWhereCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
