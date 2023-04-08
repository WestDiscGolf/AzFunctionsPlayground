using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Functions;

public class HttpFunction
{
    private readonly ILogger _logger;

    public HttpFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<HttpFunction>();
    }

    [Function("HttpFunction")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        return response;
    }
}

public class HttpFunction2
{
    [Function("HttpFunction2")]
    public async Task<Payload> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req, [] Payload payload)
    {
        payload.Name += ": Added in the function";
        return payload;
    }
}

public class Payload
{
    public string Name { get; set; }

    public Guid TenantId { get; set; }
}