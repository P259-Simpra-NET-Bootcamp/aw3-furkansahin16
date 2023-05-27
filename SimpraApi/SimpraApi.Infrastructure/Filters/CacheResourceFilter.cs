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
        if (_cache.TryGetValue(_cacheKey, out IEnumerable<EntityResponse> cachedResult) &&
            string.Equals(context.HttpContext.Request.Method, "GET", StringComparison.OrdinalIgnoreCase))
        {
            var response = GetDataFromCache(context, cachedResult);
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


    private IResponse GetDataFromCache(ResourceExecutingContext context, IEnumerable<EntityResponse> result)
    {
        if (context.HttpContext.Request.Query.Any())
        {
            var filteredValues = FilterByQuery(context, result);

            return filteredValues.Any()
                ? new SuccessDataResponse<IEnumerable<object>>(filteredValues, String.Format(Messages.ListSuccess, _modelName), HttpStatusCode.OK)
                : new ErrorResponse(String.Format(Messages.ListError, _modelName), HttpStatusCode.NoContent);
        }
        else if (context.RouteData.Values.ContainsKey("id"))
        {
            var value = context.RouteData.Values["id"]!.ToString();

            if (!int.TryParse(value, out int id))
            {
                return new ErrorResponse(Messages.ValidationError, HttpStatusCode.Forbidden)
                {
                    Errors = { $"The value:'{value}' is not valid for Id" }
                };
            }
            var entity = result.FirstOrDefault(x => x.Id == id);
            return entity is not null
                ? new SuccessDataResponse<object>(entity, Messages.GetSuccess.Format(_modelName!), HttpStatusCode.OK)
                : new ErrorResponse(Messages.GetError.Format(_modelName!, value), HttpStatusCode.NotFound);

        }
        return new SuccessDataResponse<IEnumerable<EntityResponse>>(result, String.Format(Messages.ListSuccess, _modelName), HttpStatusCode.OK); ;
    }

    private IEnumerable<object> FilterByQuery(ResourceExecutingContext context, IEnumerable<object> result)
    {
        var filterType = context.ActionDescriptor.Parameters.First().ParameterType;

        return result.Where(item =>
        context.HttpContext.Request.Query.All(query =>
        {
            var propName = query.Key.ToLower();
            var propValue = query.Value.ToString().ToLower();
            if (!filterType.GetProperties().Any(x => x.Name.ToLower() == propName)) return true;
            var prop = item.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == propName);
            var value = prop?.GetValue(item);
            if (value is int intValue)
            {
                if (int.TryParse(propValue, out var parsedValue))
                    return intValue == parsedValue;
                return false;
            }
            var stringValue = value?.ToString()?.ToLower();
            return prop is null ? true : stringValue?.Contains(propValue) ?? false;
        })).ToList();
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
            else if (context.ModelState.Root.Children is null)
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
        cacheKey = $"{modelName}_List";
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
