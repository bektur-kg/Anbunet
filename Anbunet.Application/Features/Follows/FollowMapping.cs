namespace Anbunet.Application.Features.Follows;

public class FollowMapping : Profile
{
    public FollowMapping()
    {
        CreateMap<User, FollowResponse>();

        CreateMap<User, FollowCreateRequest>();
    }
}