namespace SimpraApi.Base;
public abstract class GetByIdQueryRequest : IRequest<IResult>
{
    public int Id { get; set; }
}