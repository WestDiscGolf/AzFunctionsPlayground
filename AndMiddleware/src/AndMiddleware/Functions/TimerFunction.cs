using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AndMiddleware.Functions;

public class TimerFunction
{
    private readonly ILogger _logger;

    public TimerFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<TimerFunction>();
    }

    [Function("TimerFunction")]
    public void Run([TimerTrigger("0/15 * * * * *")] MyInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    }
}

public class MyInfo
{
    public bool IsPastDue { get; set; }
}