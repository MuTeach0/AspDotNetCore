using Microsoft.AspNetCore.Mvc.Filters;

namespace M01.ActionFilters.Filters;

public class SampleActionFilter : IActionFilter
{
    // Before Action
    public void OnActionExecuting(ActionExecutingContext context) =>
        Console.WriteLine("Sample Action Filter Sync Before");

    // After Action
    public void OnActionExecuted(ActionExecutedContext context) =>
        Console.WriteLine("Sample Action Filter Sync After");
}

public class SampleActionFilterAsync : IAsyncActionFilter
{
    // Middleware Pipeline
    // Design Pattern Chain Of Responsibility (Handler => Handler)
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("Sample Action Filter ASync Before");

        await next();
        Console.WriteLine("Sample Action Filter ASync After");
    }
}