using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace SimpraApi.Infrastructure;
public class CacheResourceFilter : IResourceFilter
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _duration;
    private readonly IConfiguration _configuration;
    private string? _cacheKey;
    private string? _modelName;

    public CacheResourceFilter(IConfiguration configuration, IMemoryCache cache)
    {
        _cache = cache;
        _configuration = configuration;
        _duration = TimeSpan.FromMinutes(_configuration.GetValue<int>("AppSettings:CacheDurationMinutes"));
    }
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        SetCacheKey(context, out _cacheKey, out _modelName);
        if (_cache.TryGetValue(_cacheKey, out object cachedResult) &&
            string.Equals(context.HttpContext.Request.Method, "GET", StringComparison.OrdinalIgnoreCase))
        {
            object? data = cachedResult is IEnumerable<object> result
                ? GetDataFromCache(context, result)
                : cachedResult;
            IResponse response = data is not null
                ? new SuccessDataResponse<object>(data, String.Format(Messages.ListSuccess, _modelName), HttpStatusCode.OK)
                : new ErrorResponse(String.Format(Messages.ListError, _modelName)
               , HttpStatusCode.NoContent);
            context.Result = new ObjectResult(response);
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        if (ValidForCache(context, out IResponse? response, out bool clearCache))
        {
            var data = GetResponseData(response!);
            _cache.Set(_cacheKey, data, _duration);
        }
        ClearCache(clearCache);
    }


    private object? GetDataFromCache(ResourceExecutingContext context, IEnumerable<object> result)
    {
        if (context.HttpContext.Request.Query.Any())
        {
            var filteredValues = result.Where(item =>
            context.HttpContext.Request.Query.All(query =>
            {
                var propName = query.Key.ToLower();
                var propValue = query.Value.ToString().ToLower();
                var prop = item.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == propName);
                var value = prop?.GetValue(item)?.ToString()?.ToLower();
                return prop is null ? true : value?.Contains(propValue) ?? false;
            })).ToList();
            return filteredValues.Any() ? filteredValues : null;
        }
        return result;
    }
    private object GetResponseData(IResponse response)
    {
        var responseType = response.GetType();
        var dataProperty = responseType.GetProperties().First(x => x.Name == "Data");
        return dataProperty.GetValue(response)!;
    }
    private bool ValidForCache(ResourceExecutedContext context, out IResponse? response, out bool clearCache)
    {
        clearCache = false;
        response = null;
        if (context.Result is ObjectResult result &&
            result.Value is IResponse value &&
            value.IsSuccess)
        {
            if (!string.Equals(context.HttpContext.Request.Method, "GET", StringComparison.OrdinalIgnoreCase)) clearCache = true;
            else if (!context.HttpContext.Request.Query.Any() ||
                     context.ModelState.Root.Children is null ||
                     context.ModelState.Root.Children.All(x => string.IsNullOrEmpty(x.AttemptedValue)))
            {
                response = value;
                return true;
            }
        }
        return false;
    }
    private void SetCacheKey(ResourceExecutingContext context, out string cacheKey, out string modelName)
    {
        modelName = context.ActionDescriptor.RouteValues["controller"]!;
        cacheKey = $"{modelName}_Get";
        foreach (var argument in context.HttpContext.Request.RouteValues.Skip(2))
        {
            cacheKey += $"_{argument.Key}:'{argument.Value}'";
        }
    }
    private void ClearCache(bool clearCache)
    {
        if (clearCache)
        {
            Type T = _cache.GetType();
            PropertyInfo prop = T!.GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public)!;
            object innerCache = prop.GetValue(_cache)!;
            Type T2 = innerCache.GetType();
            MethodInfo clearMethod = T2.GetMethod("Clear", BindingFlags.Instance | BindingFlags.Public)!;
            clearMethod.Invoke(innerCache, null);
        }
    }
}
