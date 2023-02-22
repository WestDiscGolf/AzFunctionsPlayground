using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Middleware2;

public class SampleTimerMiddleware2 : TriggerMiddlewareBase
{
    public override string TriggerType => "timerTrigger";

    protected override Task InnerInvoke(FunctionContext context)
    {
        var logger = context.GetLogger<SampleTimerMiddleware2>();
        logger.LogWarning("Running timer trigger middleware from derived type.");
        return Task.CompletedTask;
    }
}