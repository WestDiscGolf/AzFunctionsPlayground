using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Middleware1;

public class ExceptionLoggingMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var log = context.GetLogger<ExceptionLoggingMiddleware>();
            log.LogWarning(ex, string.Empty);
        }
    }
}