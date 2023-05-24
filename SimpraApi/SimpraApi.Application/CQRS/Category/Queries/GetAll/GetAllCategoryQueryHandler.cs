using System.Linq.Expressions;

namespace SimpraApi.Application;

public class GetAllCategoryQueryHandler : GetAllQueryHandler<Category, GetAllCategoryQueryRequest, CategoryDetailDto>
{
    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
