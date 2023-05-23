namespace SimpraApi.Base;

public class SuccessDataResult<T> : CommonDataResult<T> where T : EntityResponse
{
    public SuccessDataResult(T data) : base(true, data) { }
    public SuccessDataResult(T data, string message) : base(true, data, message) { }
    public SuccessDataResult(T data, string message, HttpStatusCode statusCode) : base(true, data, message, statusCode) { }
    public SuccessDataResult(IEnumerable<T> data) : base(true, data) { }
    public SuccessDataResult(IEnumerable<T> data, string message) : base(true, data, message) { }
    public SuccessDataResult(IEnumerable<T> data, string message, HttpStatusCode statusCode) : base(true, data, message, statusCode) { }
}