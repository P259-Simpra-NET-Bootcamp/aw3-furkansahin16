namespace SimpraApi.Base;
public abstract class EntityDeleteCommandRequest : IRequest<IResult>
{
    public int Id { get; set; }
}
