using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((ctx, app) =>
    {
        app.UseMiddleware<ExceptionLoggingMiddleware>();

        app.UseWhen<SampleHttpMiddleware>(MiddlewarePredicates.IsHttp);
        app.UseWhen<SampleTriggerMiddleware>(MiddlewarePredicates.IsTrigger);
        
    })
    .Build();

host.Run();