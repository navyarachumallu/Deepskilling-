using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment _environment;

    public CustomExceptionFilter(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public void OnException(ExceptionContext context)
    {
        var logPath = Path.Combine(_environment.ContentRootPath, "exception.log");
        File.AppendAllText(logPath, $"[{DateTime.UtcNow:O}] {context.Exception}\n");

        context.Result = new ObjectResult(new { error = context.Exception.Message })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        context.ExceptionHandled = true;
    }
}
