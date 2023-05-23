namespace SimpraApi.Application;

public class CategoryDetailDto : EntityResponse
{
    public string Name { get; set; } = null!;
    public int ProductCount { get; set; }
}