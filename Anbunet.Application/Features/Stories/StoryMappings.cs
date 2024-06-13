namespace Anbunet.Application.Features.Stories;

public class StoryMappings : Profile
{
    public StoryMappings()
    {
        CreateMap<Story, ProfileStoryResponse>().ReverseMap();
        CreateMap<FollowingStoriesResponse, User>().ReverseMap();
        CreateMap<Story, CreateStoryRequest>();
        CreateMap<Story, ActualStoryResponse>();

    }
}