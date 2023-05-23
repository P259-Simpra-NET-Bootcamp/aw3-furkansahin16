namespace SimpraApi.Base;

public class ErrorDataResult<T> : CommonDataResult<T> where T : class
{
    public List<string> Errors { get; set; } = new();
    public ErrorDataResult(T data) : base(false, data) { }
    public ErrorDataResult(T data, string message) : base(false, data, message) { }
    public ErrorDataResult(T data, string message, HttpStatusCode statusCode) : base(false, data, message, statusCode) { }
}