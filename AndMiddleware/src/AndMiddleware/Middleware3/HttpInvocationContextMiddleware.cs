using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndMiddleware.Functions;
using AndMiddleware.Middleware2;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace AndMiddleware.Middleware3;
public class HttpInvocationContextMiddleware : TriggerMiddlewareBase
{
    public override string TriggerType => "httpTrigger";

    protected override async Task InnerInvoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var blobBindingMetaData = context.FunctionDefinition
            .InputBindings.Values
            .FirstOrDefault(a => a.Name == "payload");

        if (blobBindingMetaData != null) 
        {
            var bindingResult = await context.BindInputAsync<Payload>(blobBindingMetaData);
            bindingResult.Value.TenantId = Guid.NewGuid();
            //bindingResult.Value = new MyBlob { Name = "Totally different object" };
        }

        await next(context);

        //var payload = context.GetInvocationResult<Payload>();
        //payload.Value.TenantId = Guid.NewGuid();

    }
}
