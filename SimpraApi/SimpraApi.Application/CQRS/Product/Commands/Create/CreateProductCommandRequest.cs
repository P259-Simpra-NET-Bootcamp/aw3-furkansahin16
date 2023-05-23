namespace SimpraApi.Application;
public class CreateProductCommandRequest : CreateCommandRequest
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public int CategoryId { get; set; }
}