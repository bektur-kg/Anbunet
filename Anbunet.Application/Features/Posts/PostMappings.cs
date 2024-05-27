using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Modules.Posts;
using AutoMapper;

namespace Anbunet.Application.Features.Posts;

public class PostMappings : Profile
{
    public PostMappings()
    {
        CreateMap<Post, PostDetailedResponse>();
    }
}

