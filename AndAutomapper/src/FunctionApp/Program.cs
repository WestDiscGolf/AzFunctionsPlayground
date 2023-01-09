using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));
    })
    .Build();

host.Run();

public partial class Program { }