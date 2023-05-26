using Microsoft.AspNetCore.Mvc;

namespace SimpraApi.Infrastructe;

public class ValidationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var result = new ErrorResponse(Messages.ValidationError, HttpStatusCode.Forbidden);
            result.Errors = context.ModelState.Values
                .SelectMany(modelState => modelState.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();
            context.Result = new ObjectResult(result);
        }
    }
}
