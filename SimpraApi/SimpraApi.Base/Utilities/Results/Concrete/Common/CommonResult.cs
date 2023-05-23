namespace SimpraApi.Base.Results.Concrete.Common;
public abstract class CommonResult : IResult
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public HttpStatusCode? StatusCode { get; set; }
    public CommonResult(bool isSuccess, string message)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
    }

    public CommonResult(bool isSuccess, string message, HttpStatusCode statusCode)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
        this.StatusCode = statusCode;
    }

    public CommonResult(bool isSuccess) : this(isSuccess, isSuccess ? "Success" : "Error") { }
}