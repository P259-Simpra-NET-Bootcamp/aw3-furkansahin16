namespace SimpraApi.Application;
public class CreateCategoryCommandHandler : CreateCommandHandler<Category, CreateCategoryCommandRequest, CategoryDto>
{
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
