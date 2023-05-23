namespace SimpraApi.Base;
public abstract class DeleteCommandRequest : IRequest<IResult>
{
    public int Id { get; set; }
}
