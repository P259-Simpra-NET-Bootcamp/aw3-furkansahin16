using System.Text.Json.Serialization;

namespace SimpraApi.Application;
public class ProductDto : EntityResponse
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Tag { get; set; } = null!;

    [JsonIgnore]
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; } = null!;
}
