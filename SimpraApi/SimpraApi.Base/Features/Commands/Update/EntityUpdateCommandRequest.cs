namespace SimpraApi.Base;
public abstract class EntityUpdateCommandRequest : IRequest<IResult>
{
    public int Id { get; set; }
}
