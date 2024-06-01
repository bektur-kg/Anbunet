using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Modules.Posts;
using AutoMapper;

namespace Anbunet.Application.Features.Posts;

public class PostMappings : Profile
{
    public PostMappings()
    {
        CreateMap<Post, PostDetailedResponse>();

        CreateMap<Post, PostUpdateRequest>();

        CreateMap<Post, ProfilePostResponse>()
            .ForMember(
                dest => dest.LikesCount,
                opt => opt.MapFrom(src => src.Likes.Count)
            )
            .ForMember(
                dest => dest.CommentsCount,
                opt => opt.MapFrom(src => src.Comments.Count)
            );
    }
}

