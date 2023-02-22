using AndMiddleware.Middleware1;
using AndMiddleware.Middleware2;
using Microsoft.Extensions.Hosting;

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