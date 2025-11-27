using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace M02.ResourceFilters.Filters;

public class TenantValidationFilter(IConfiguration configuration) : IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(
        ResourceExecutingContext context,
        ResourceExecutionDelegate next)
    {
        var TenantId = context.HttpContext.Request.Headers["TENANT-ID"].ToString();
        var ApiKey = context.HttpContext.Request.Headers["X-API-KEY"].ToString();

        var ExpectedKey = configuration[$"Tenants:{TenantId}:ApiKey"];

        if (string.IsNullOrEmpty(ExpectedKey) || ExpectedKey != ApiKey)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();

    }
}