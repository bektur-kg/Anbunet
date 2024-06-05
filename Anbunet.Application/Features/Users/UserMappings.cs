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
        CreateMap<User, UserDetailedResponse>();
        CreateMap<UpdateUserRequest, User>()
           .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}

