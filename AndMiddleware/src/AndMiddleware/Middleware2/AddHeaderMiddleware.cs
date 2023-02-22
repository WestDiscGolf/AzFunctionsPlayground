using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace AndMiddleware.Middleware2;

public class AddHeaderMiddleware : TriggerMiddlewareBase
{
    public override string TriggerType => "httpTrigger";

    protected override async Task InnerInvoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        await next(context);

        var responseData = context.GetHttpResponseData();
        responseData!.Headers.Add("x-my-header", Guid.NewGuid().ToString());
    }
}