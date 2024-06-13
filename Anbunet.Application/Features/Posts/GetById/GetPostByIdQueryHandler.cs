namespace Anbunet.Application.Features.Posts.GetById;

public class GetPostByIdQueryHandler 
    (
        IPostRepository postRepository,
        ILikeRepository likeRepository,
        ICommentRepository commentRepository,
        IMapper mapper
    )
    : IQueryHandler<GetPostByIdQuery, ValueResult<PostDetailedResponse>>
{
    public async Task<ValueResult<PostDetailedResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdWithIncludeAsync(request.Id, includeUser: true);
        var postLikes = await likeRepository.GetPostLikesWithIncludeAsync(request.Id, includeUser: true);
        var postComments = await commentRepository.GetPostCommentsWithIncludeAsync(request.Id, includeUser: true);

        if (foundPost is null) return ValueResult<PostDetailedResponse>.Failure(PostErrors.PostNotFound);

        var mappedPost = mapper.Map<PostDetailedResponse>(foundPost);
        var mappedLikes = mapper.Map<List<LikeResponse>>(postLikes);
        var mappedComments = mapper.Map<List<CommentResponse>>(postComments);

        mappedPost.Likes = mappedLikes;
        mappedPost.Comments = mappedComments;

        return ValueResult<PostDetailedResponse>.Success(mappedPost);
    }
}