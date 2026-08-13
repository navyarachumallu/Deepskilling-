using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApi.Filters;

public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var headers = context.HttpContext.Request.Headers;

        if (!headers.ContainsKey("Authorization"))
        {
            context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
            return;
        }

        var authHeader = headers["Authorization"].ToString();
        if (!authHeader.Contains("Bearer", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
        }
    }
}
