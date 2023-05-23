namespace SimpraApi.Base;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public Status Status { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
