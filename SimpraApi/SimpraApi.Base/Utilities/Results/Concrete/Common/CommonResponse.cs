namespace SimpraApi.Base.Responses.Concrete.Common;
public abstract class CommonResponse : IResponse
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public HttpStatusCode? StatusCode { get; set; }
    public CommonResponse(bool isSuccess, string message)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
    }

    public CommonResponse(bool isSuccess, string message, HttpStatusCode statusCode)
    {
        this.IsSuccess = isSuccess;
        this.Message = message;
        this.StatusCode = statusCode;
    }

    public CommonResponse(bool isSuccess) : this(isSuccess, isSuccess ? "Success" : "Error") { }
}