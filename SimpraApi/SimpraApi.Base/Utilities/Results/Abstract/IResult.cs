namespace SimpraApi.Base;
public interface IResult
{
    bool IsSuccess { get; }
    string Message { get; }
}
