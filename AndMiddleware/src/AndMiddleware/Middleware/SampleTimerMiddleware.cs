using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Middleware;

public class SampleTimerMiddleware : IFunctionsWorkerMiddleware
{
    public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var logger = context.GetLogger<SampleTimerMiddleware>();
        logger.LogInformation("Running timer trigger middleware.");

        // do stuff
        return next(context);
    }
}