using AndMiddleware.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((ctx, app) =>
    {
        app.UseMiddleware<ExceptionLoggingMiddleware>();

        //app.UseWhen<SampleHttpMiddleware>(MiddlewarePredicates.IsHttp);
        //app.UseWhen<SampleTimerMiddleware>(MiddlewarePredicates.IsTrigger);

        app.UseMiddleware<SampleHttpMiddleware2>();
        app.UseMiddleware<SampleTimerMiddleware2>();

    })
    .Build();

host.Run();

public abstract class TriggerMiddleware : IFunctionsWorkerMiddleware
{
    public abstract string Type { get; }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        if (context.FunctionDefinition.InputBindings.Values.First(x => x.Type.EndsWith("Trigger")).Type == Type)
        {
            await InnerInvoke(context);
        }

        await next(context);
    }

    public abstract Task InnerInvoke(FunctionContext context);
}

public class SampleHttpMiddleware2 : TriggerMiddleware
{
    public override string Type => "httpTrigger";
    public override Task InnerInvoke(FunctionContext context)
    {
        var logger = context.GetLogger<SampleHttpMiddleware>();
        logger.LogWarning("Running http middleware from derived type.");
        return Task.CompletedTask;
    }
}

public class SampleTimerMiddleware2 : TriggerMiddleware
{
    public override string Type => "timerTrigger";

    public override Task InnerInvoke(FunctionContext context)
    {
        var logger = context.GetLogger<SampleTimerMiddleware2>();
        logger.LogWarning("Running timer trigger middleware from derived type.");
        return Task.CompletedTask;
    }
}