namespace SimpraApi.Application;

public class UpdateCategoryCommandHandler : UpdateCommandHandler<Category, UpdateCategoryCommandRequest, CategoryDto>
{
    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public override async Task<IResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (TryToGetById(request.Id, out IResponse? response) &&
            await Repository.AnyAsync(x => x.Name == request.Name.NormalizeString(), true) &&
            !String.Equals(Entity!.Name, request.Name, StringComparison.OrdinalIgnoreCase))
        {
            return new ErrorResponse(Messages.UniqueFieldError.Format("Name", request.Name), HttpStatusCode.Forbidden);
        }
        return await base.Handle(request, cancellationToken);
    }
}
