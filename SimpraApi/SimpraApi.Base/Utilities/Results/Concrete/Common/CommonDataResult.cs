namespace SimpraApi.Base.Results.Concrete.Common;
public abstract class CommonDataResult<T> : CommonResult, IDataResult<T>
where T : class
{
    public object Data { get; set; } = null!;
    public CommonDataResult(bool isSuccess, T data) : base(isSuccess) => this.Data = data;
    public CommonDataResult(bool isSuccess, T data, string message) : base(isSuccess, message) => this.Data = data;
    public CommonDataResult(bool isSuccess, T data, string message, HttpStatusCode statusCode) : base(isSuccess, message, statusCode) => this.Data = data;
    public CommonDataResult(bool isSuccess, IEnumerable<T> data) : base(isSuccess) => this.Data = data;
    public CommonDataResult(bool isSuccess, IEnumerable<T> data, string message) : base(isSuccess, message) => this.Data = data;
    public CommonDataResult(bool isSuccess, IEnumerable<T> data, string message, HttpStatusCode statusCode) : base(isSuccess, message, statusCode) => this.Data = data;
}