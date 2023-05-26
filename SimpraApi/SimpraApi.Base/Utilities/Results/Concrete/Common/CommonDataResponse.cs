namespace SimpraApi.Base.Responses.Concrete.Common;
public abstract class CommonDataResponse<T> : CommonResponse, IDataResponse<T>
where T : class
{
    public object Data { get; set; } = null!;
    public CommonDataResponse(bool isSuccess, T data) : base(isSuccess) => this.Data = data;
    public CommonDataResponse(bool isSuccess, T data, string message) : base(isSuccess, message) => this.Data = data;
    public CommonDataResponse(bool isSuccess, T data, string message, HttpStatusCode statusCode) : base(isSuccess, message, statusCode) => this.Data = data;
    public CommonDataResponse(bool isSuccess, IEnumerable<T> data) : base(isSuccess) => this.Data = data;
    public CommonDataResponse(bool isSuccess, IEnumerable<T> data, string message) : base(isSuccess, message) => this.Data = data;
    public CommonDataResponse(bool isSuccess, IEnumerable<T> data, string message, HttpStatusCode statusCode) : base(isSuccess, message, statusCode) => this.Data = data;
}