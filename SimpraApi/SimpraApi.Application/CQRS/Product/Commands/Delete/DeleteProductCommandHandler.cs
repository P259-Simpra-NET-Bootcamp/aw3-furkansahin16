namespace SimpraApi.Application;

public class DeleteProductCommandHandler : DeleteCommandHandler<Product, DeleteProductCommandRequest>
{
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }
}
