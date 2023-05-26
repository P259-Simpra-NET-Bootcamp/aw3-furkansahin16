namespace SimpraApi.Base;
public abstract class UpdateCommandRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}
