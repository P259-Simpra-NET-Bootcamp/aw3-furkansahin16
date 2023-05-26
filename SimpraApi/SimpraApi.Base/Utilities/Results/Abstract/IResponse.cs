namespace SimpraApi.Base;
public interface IResponse
{
    bool IsSuccess { get; }
    string Message { get; }
}
