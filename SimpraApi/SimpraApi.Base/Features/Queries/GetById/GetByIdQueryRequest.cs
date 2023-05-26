namespace SimpraApi.Base;
public abstract class GetByIdQueryRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}