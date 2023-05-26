namespace SimpraApi.Base;
public abstract class DeleteCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}
