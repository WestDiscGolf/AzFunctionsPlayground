using Microsoft.Azure.Functions.Worker;

namespace AndMiddleware.Middleware;

public static class MiddlewarePredicates
{
    public static bool IsHttp(FunctionContext context) 
        => context.FunctionDefinition.InputBindings.Values.First(a => a.Type.EndsWith("Trigger")).Type == "httpTrigger";

    public static bool IsTrigger(FunctionContext context)
        => context.FunctionDefinition.InputBindings.Values.First(a => a.Type.EndsWith("Trigger")).Type == "timerTrigger";
}