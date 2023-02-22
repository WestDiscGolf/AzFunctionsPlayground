using AndMiddleware.Middleware1;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Middleware2;

public class SampleHttpMiddleware2 : TriggerMiddlewareBase
{
    public override string TriggerType => "httpTrigger";

    protected override Task InnerInvoke(FunctionContext context)
    {
        var logger = context.GetLogger<SampleHttpMiddleware>();
        logger.LogWarning("Running http middleware from derived type.");
        return Task.CompletedTask;
    }
}

public class AddHeaderMiddleware : TriggerMiddlewareBase
{
    public override string TriggerType => "httpTrigger";

    protected override Task InnerInvoke(FunctionContext context)
    {
        var responseData = context.GetHttpResponseData();
        responseData.Headers.Add("x-my-header", Guid.NewGuid().ToString());
        return Task.CompletedTask;
    }
}