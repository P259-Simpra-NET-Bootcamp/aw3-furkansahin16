namespace SimpraApi.Application;
public class CreateCategoryCommandRequest : CreateCommandRequest
{
    public string Name { get; set; } = null!;
}