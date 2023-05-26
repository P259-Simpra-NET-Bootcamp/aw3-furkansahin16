namespace SimpraApi.Base;

public class SuccessDataResponse<T> : CommonDataResponse<T> where T : class
{
    public SuccessDataResponse(T data) : base(true, data) { }
    public SuccessDataResponse(T data, string message) : base(true, data, message) { }
    public SuccessDataResponse(T data, string message, HttpStatusCode statusCode) : base(true, data, message, statusCode) { }
    public SuccessDataResponse(IEnumerable<T> data) : base(true, data) { }
    public SuccessDataResponse(IEnumerable<T> data, string message) : base(true, data, message) { }
    public SuccessDataResponse(IEnumerable<T> data, string message, HttpStatusCode statusCode) : base(true, data, message, statusCode) { }
}