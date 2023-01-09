using System.Net;
using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace FunctionApp;

public class MappingFunction
{
    private readonly IMapper _mapper;

    public MappingFunction(IMapper mapper)
    {
        _mapper = mapper;
    }

    [Function("Mapping")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);

        var entity = new DummyEntity { Name = "My Named Entity" };
        await response.WriteAsJsonAsync(_mapper.Map<DummyResponse>(entity));

        return response;
    }
}