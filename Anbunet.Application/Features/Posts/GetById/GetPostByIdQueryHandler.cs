using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Application.Contracts.Likes;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using AutoMapper;

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
        var foundPost = await postRepository.GetByIdWithInclude(request.Id, includeUser: true);
        var postLikes = await likeRepository.GetPostLikesWithInclude(request.Id, includeUser: true);
        var postComments = await commentRepository.GetPostCommentsWithInclude(request.Id, includeUser: true);

        if (foundPost is null) return ValueResult<PostDetailedResponse>.Failure(PostErrors.PostNotFound);

        foundPost.MediaUrl = "https://localhost:7199/" + foundPost.MediaUrl;

        var mappedPost = mapper.Map<PostDetailedResponse>(foundPost);
        var mappedLikes = mapper.Map<List<LikeResponse>>(postLikes);
        var mappedComments = mapper.Map<List<CommentResponse>>(postComments);

        mappedPost.Likes = mappedLikes;
        mappedPost.Comments = mappedComments;

        return ValueResult<PostDetailedResponse>.Success(mappedPost);
    }
}