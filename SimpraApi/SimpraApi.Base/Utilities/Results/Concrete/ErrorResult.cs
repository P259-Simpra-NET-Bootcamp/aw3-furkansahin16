namespace SimpraApi.Base;

public class ErrorResult : CommonResult
{
    public List<string> Errors { get; set; } = new();
    public ErrorResult(string message) : base(false, message) { }
    public ErrorResult(string message, HttpStatusCode statusCode) : base(false, message, statusCode) { }
    public ErrorResult() : base(false) { }
}