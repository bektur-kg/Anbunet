using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Posts;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Likes.GetAll;

public class GetAllLikeCommandHandler
    (
        IPostRepository postRepository,
        IUserRepository userRepository,
        IMapper _mapper
    )
    : ICommandHandler<GetAllLikeCommand, ValueResult<List<UserLikeResponse>>>
{

    public async Task<ValueResult<List<UserLikeResponse>>> Handle(GetAllLikeCommand request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdWithIncludeAndTracking(request.PostId, includeLikes: true);

        if (foundPost is null) return ValueResult<List<UserLikeResponse>>.Failure(PostErrors.PostNotFound);

        var usersWhoHaveLiked = foundPost.Likes.Select(l => l.User);

        var result = _mapper.Map<List<UserLikeResponse>>(usersWhoHaveLiked);

        return ValueResult<List<UserLikeResponse>>.Success(result);
    }
}
