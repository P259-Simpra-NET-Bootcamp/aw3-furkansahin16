namespace SimpraApi.Application;

public class UpdateCategoryCommandRequest : UpdateCommandRequest
{
    public string Name { get; set; } = null!;
}
