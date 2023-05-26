﻿namespace SimpraApi.Infrastructe;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var result = new ErrorResponse(Messages.ValidationError, HttpStatusCode.Forbidden);
            result.Errors = context.ModelState.Values
                .SelectMany(modelState => modelState.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();
        }
        await next();
    }
}
