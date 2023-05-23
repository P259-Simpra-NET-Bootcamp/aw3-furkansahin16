namespace SimpraApi.Application;

public class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<CreateProductCommandRequest, Product>()
			.ForMember(x => x.Name, cfg => cfg.MapFrom(src => src.Name.NormalizeString()));
		CreateMap<UpdateProductCommandRequest, Product>()
            .ForMember(x => x.Name, cfg => cfg.MapFrom(src => src.Name.NormalizeString()));
        CreateMap<Product, ProductDto>();
	}
}