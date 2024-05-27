using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using AutoMapper;

namespace Anbunet.Application.Features.Comments.GetAllComments;

public class GetAllCommentsByPostIdQueryHandler(
        ICommentRepository commentRepository,
        IMapper mapper
    ) : ICommandHandler<GetAllCommentsByPostIdQuery, ValueResult<List<CommentResponse>>>
{
    public async Task<ValueResult<List<CommentResponse>>> Handle(GetAllCommentsByPostIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await commentRepository.GetAllByPostIdAsync(request.postId);

        if (comments is null) return ValueResult<List<CommentResponse>>.Failure(CommentErrors.CommentNotFound);

        var mappedComment = mapper.Map<List<CommentResponse>>(comments);

        return ValueResult<List<CommentResponse>>.Success(mappedComment);
    }
} 