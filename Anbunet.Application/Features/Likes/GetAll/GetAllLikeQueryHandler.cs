using Anbunet.Application.Features.Posts;

namespace Anbunet.Application.Features.Likes.GetAll;

public class GetAllLikeQueryHandler
    (
        IPostRepository postRepository,
        ILikeRepository likeRepository,
        IMapper _mapper
    )
    : ICommandHandler<GetAllLikeQuery, ValueResult<List<LikeResponse>>>
{

    public async Task<ValueResult<List<LikeResponse>>> Handle(GetAllLikeQuery request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdAsync(request.PostId);
        if (foundPost is null) return ValueResult<List<LikeResponse>>.Failure(PostErrors.PostNotFound);

        var postLikes = await likeRepository.GetPostLikesWithIncludeAsync(request.PostId, includeUser: true);

        var result = _mapper.Map<List<LikeResponse>>(postLikes);

        return ValueResult<List<LikeResponse>>.Success(result);
    }
}