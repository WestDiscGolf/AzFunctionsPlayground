using Microsoft.Azure.Functions.Worker;

namespace AndMiddleware.Middleware1;

public static class MiddlewarePredicates
{
    public static bool IsHttp(FunctionContext context) 
        => context.FunctionDefinition.InputBindings.Values.First(a => a.Type.EndsWith("Trigger")).Type == "httpTrigger";

    public static bool IsTrigger(FunctionContext context)
        => context.FunctionDefinition.InputBindings.Values.First(a => a.Type.EndsWith("Trigger")).Type == "timerTrigger";

    public static bool IsTriggeredBy(this FunctionContext context, string triggerType)
        => context.FunctionDefinition.InputBindings.Values.First(a => a.Type.EndsWith("Trigger")).Type == triggerType;
}