using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Modules.Stories;
using AutoMapper;

namespace Anbunet.Application.Features.Stories;

public class StoryMappings : Profile
{
    public StoryMappings()
    {
        CreateMap<Story, ProfileStoryResponse>();
        CreateMap<Story, CreateStoryRequest>();
        CreateMap<Story, ActualStoryResponse>();
    }
}

