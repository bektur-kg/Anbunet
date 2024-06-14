namespace Anbunet.Application.Features.Actuals;

public class ActualMappings : Profile
{
    public ActualMappings()
    {
        CreateMap<Actual, ProfileActualResponse>();

        CreateMap<Actual, CreateActualRequest>();

        CreateMap<Actual, AddStoriesRequest>();
    }
}

