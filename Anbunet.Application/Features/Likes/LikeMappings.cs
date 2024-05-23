using Anbunet.Application.Contracts.Likes;
using Anbunet.Domain.Modules.Likes;
using AutoMapper;

namespace Anbunet.Application.Features.Likes;

public class LikeMappings : Profile
{
    public LikeMappings()
    {
        CreateMap<Like, LikeResponse>();
    }
}

