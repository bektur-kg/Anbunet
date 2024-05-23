using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Users;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<User, UserPostResponse>();
        CreateMap<User, UserCommentResponse>();
        CreateMap<User, UserLikeResponse>();
    }
}

