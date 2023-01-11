using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FunctionApp
{
    public class Function1
    {
        private readonly IOptions<Settings> _options;
        private readonly ILogger _logger;

        public Function1(IOptions<Settings> options, ILoggerFactory loggerFactory)
        {
            _options = options;
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(_options.Value.Name);

            return response;
        }
    }
}
