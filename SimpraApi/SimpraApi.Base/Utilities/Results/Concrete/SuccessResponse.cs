namespace SimpraApi.Base;
public class SuccessResponse : CommonResponse
{
    public SuccessResponse() : base(true) { }
    public SuccessResponse(string message) : base(true, message) { }
    public SuccessResponse(string message, HttpStatusCode statusCode) : base(true, message, statusCode) { }
}