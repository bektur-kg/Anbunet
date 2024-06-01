using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Contracts.Likes;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Follows;

public class FollowMapping : Profile
{
    public FollowMapping()
    {
        CreateMap<User, FollowResponse>();

        CreateMap<User, FollowCreateRequest>();
    }
}
