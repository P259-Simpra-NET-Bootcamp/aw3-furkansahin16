namespace SimpraApi.Application;

public class UpdateCategoryCommandHandler : UpdateCommandHandler<Category, UpdateCommandRequest, CategoryDto>
{
    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
