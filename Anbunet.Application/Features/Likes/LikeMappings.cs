namespace Anbunet.Application.Features.Likes;

public class LikeMappings : Profile
{
    public LikeMappings()
    {
        CreateMap<Like, LikeResponse>();
    }
}