namespace SimpraApi.Application;
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryCommandRequest, Category>()
            .ForMember(x => x.Name, cfg => cfg.MapFrom(src => src.Name.NormalizeString()));
        CreateMap<UpdateCategoryCommandRequest, Category>()
            .ForMember(x => x.Name, cfg => cfg.MapFrom(src => src.Name.NormalizeString()));
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryDetailDto>()
            .ForMember(x => x.ProductCount, cfg => cfg.MapFrom(src => src.Products.Count));
    }
}