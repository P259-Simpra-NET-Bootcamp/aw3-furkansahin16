namespace SimpraApi.Base;
public abstract class UpdateCommandRequest : IRequest<IResult>
{
    public int Id { get; set; }
}
