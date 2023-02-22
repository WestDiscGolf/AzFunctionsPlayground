using AndMiddleware.Middleware1;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace AndMiddleware.Middleware2;

public abstract class TriggerMiddlewareBase : IFunctionsWorkerMiddleware
{
    public abstract string TriggerType { get; }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        // always run the next middleware if not applicable to the current trigger type.
        await (context.IsTriggeredBy(TriggerType) ? InnerInvoke(context, next) : next(context));
    }

    protected abstract Task InnerInvoke(FunctionContext context, FunctionExecutionDelegate next);
}