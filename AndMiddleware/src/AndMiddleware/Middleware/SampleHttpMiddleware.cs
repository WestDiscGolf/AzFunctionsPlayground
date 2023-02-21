using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Middleware;

public class SampleHttpMiddleware : IFunctionsWorkerMiddleware
{
    public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var logger = context.GetLogger<SampleHttpMiddleware>();
        logger.LogInformation("Running http middleware.");

        // do stuff
        return next(context);
    }
}