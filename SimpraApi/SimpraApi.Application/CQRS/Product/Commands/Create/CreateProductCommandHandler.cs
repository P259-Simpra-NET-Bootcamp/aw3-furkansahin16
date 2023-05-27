namespace SimpraApi.Application;
public class CreateProductCommandHandler : CreateCommandHandler<Product, CreateProductCommandRequest, ProductDto>
{
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) => _mapper = mapper;
    public async override Task<IResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (await Repository.AnyAsync(x => x.Name == request.Name.NormalizeString(), true))
        {
            return new ErrorResponse(Messages.UniqueFieldError.Format("Name", request.Name), HttpStatusCode.Forbidden);
        }
        var category = await UnitOfWork.GetRepository<Category>().GetAsync(x => x.Id == request.CategoryId);
        if (category is null)
        {
            return new ErrorResponse(Messages.GetError.Format(nameof(Category), request.CategoryId.ToString()), HttpStatusCode.NotFound);
        }

        return await base.Handle(request, cancellationToken);
    }
}