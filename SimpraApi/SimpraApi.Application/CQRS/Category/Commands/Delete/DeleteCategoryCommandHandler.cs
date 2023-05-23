namespace SimpraApi.Application;

public class DeleteCategoryCommandHandler : DeleteCommandHandler<Category, DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }
}
