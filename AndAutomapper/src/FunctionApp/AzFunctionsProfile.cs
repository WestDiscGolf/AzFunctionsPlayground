using AutoMapper;

public class AzFunctionsProfile : Profile
{
    public AzFunctionsProfile()
    {
        CreateMap<DummyEntity, DummyResponse>()
            .ForMember(x => x.Id, opts => opts.MapFrom(x=> x.Id.ToString()))
            .ForMember(x => x.DisplayName, opts => opts.MapFrom(x => x.Name));
    }
}