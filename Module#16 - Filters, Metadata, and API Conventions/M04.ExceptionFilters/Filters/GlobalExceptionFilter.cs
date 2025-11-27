using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace M04.ExceptionFilters.Filters;

public class GlobalExceptionFilter : IAsyncExceptionFilter
{
    /* (OnExceptionAsync)
            Called after an action has thrown an Exception.

        Returns:
            A Task that on completion indicates the filter has executed.
    */
    public Task OnExceptionAsync(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = context.Exception.Message
        };
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };

        context.ExceptionHandled = true;
        
        return Task.CompletedTask;
    }
}