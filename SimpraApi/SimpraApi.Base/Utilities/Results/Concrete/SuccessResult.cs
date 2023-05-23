namespace SimpraApi.Base;
public class SuccessResult : CommonResult
{
    public SuccessResult() : base(true) { }
    public SuccessResult(string message) : base(true, message) { }
    public SuccessResult(string message, HttpStatusCode statusCode) : base(true, message, statusCode) { }
}