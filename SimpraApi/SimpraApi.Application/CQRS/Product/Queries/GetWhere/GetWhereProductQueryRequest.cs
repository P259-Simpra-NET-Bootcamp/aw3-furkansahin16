namespace SimpraApi.Application;

public class GetWhereProductQueryRequest : GetWhereQueryRequest
{
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
}