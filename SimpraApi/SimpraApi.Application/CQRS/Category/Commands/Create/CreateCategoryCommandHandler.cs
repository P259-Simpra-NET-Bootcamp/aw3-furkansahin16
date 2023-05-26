namespace SimpraApi.Application;
public class CreateCategoryCommandHandler : CreateCommandHandler<Category, CreateCategoryCommandRequest, CategoryDto>
{
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public override async Task<IResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (await Repository.AnyAsync(x => x.Name == request.Name.NormalizeString(),true))
        {
            return new ErrorResponse(Messages.UniqueFieldError.Format("Name", request.Name), HttpStatusCode.Forbidden);
        }
        return await base.Handle(request, cancellationToken);
    }
}
