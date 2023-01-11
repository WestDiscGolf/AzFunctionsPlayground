using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((host, services) =>
    {
        services.Configure<Settings>(host.Configuration.GetSection("Settings"));
    })
    .Build();

host.Run();