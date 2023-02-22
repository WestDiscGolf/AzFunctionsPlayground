using AndMiddleware.Middleware1;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace AndMiddleware.Middleware2;

public abstract class TriggerMiddlewareBase : IFunctionsWorkerMiddleware
{
    public abstract string TriggerType { get; }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        if (context.IsTriggeredBy(TriggerType))
        {
            await InnerInvoke(context);
        }

        await next(context);
    }

    protected abstract Task InnerInvoke(FunctionContext context);
}