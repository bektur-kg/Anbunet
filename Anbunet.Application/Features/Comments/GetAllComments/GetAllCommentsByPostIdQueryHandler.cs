namespace Anbunet.Application.Features.Comments.GetAllComments;

public class GetAllCommentsByPostIdQueryHandler(
        ICommentRepository commentRepository,
        IMapper mapper
    ) : IQueryHandler<GetAllCommentsByPostIdQuery, ValueResult<List<CommentResponse>>>
{
    public async Task<ValueResult<List<CommentResponse>>> Handle(GetAllCommentsByPostIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await commentRepository.GetPostCommentsWithIncludeAsync(request.PostId, includeUser:true);

        var mappedComment = mapper.Map<List<CommentResponse>>(comments);

        return ValueResult<List<CommentResponse>>.Success(mappedComment);
    }
}