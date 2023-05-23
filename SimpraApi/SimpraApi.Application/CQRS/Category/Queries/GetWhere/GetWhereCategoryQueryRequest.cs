namespace SimpraApi.Application;

public class GetWhereCategoryQueryRequest : GetWhereQueryRequest
{
    public string Name { get; set; } = null!;
}