using AndMiddleware.Middleware1;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Middleware2;

public class SampleHttpMiddleware2 : TriggerMiddlewareBase
{
    public override string TriggerType => "httpTrigger";

    protected override Task InnerInvoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var logger = context.GetLogger<SampleHttpMiddleware>();
        logger.LogWarning("Running http middleware from derived type.");
        return next(context);
    }
}