namespace SimpraApi.Application;

public class GetByIdCategoryQueryHandler : GetByIdQueryHandler<Category, GetByIdCategoryQueryRequest, CategoryDetailDto>
{
    public GetByIdCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
