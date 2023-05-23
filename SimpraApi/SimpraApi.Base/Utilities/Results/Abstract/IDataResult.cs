namespace SimpraApi.Base;

public interface IDataResult<T> : IResult where T : class
{
    object Data { get; }
}
