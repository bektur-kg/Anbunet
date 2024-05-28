using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Likes;
using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Posts;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Likes.GetAll;

public class GetAllLikeQueryHandler
    (
        IPostRepository postRepository,
        ILikeRepository likeRepository,
        IUserRepository userRepository,
        IMapper _mapper
    )
    : ICommandHandler<GetAllLikeQuery, ValueResult<List<LikeResponse>>>
{

    public async Task<ValueResult<List<LikeResponse>>> Handle(GetAllLikeQuery request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdAsync(request.PostId);
        if (foundPost is null) return ValueResult<List<LikeResponse>>.Failure(PostErrors.PostNotFound);

        var postLikes = await likeRepository.GetPostLikesWithInclude(request.PostId, includeUser: true);

        var result = _mapper.Map<List<LikeResponse>>(postLikes);


        return ValueResult<List<LikeResponse>>.Success(result);
    }
}
