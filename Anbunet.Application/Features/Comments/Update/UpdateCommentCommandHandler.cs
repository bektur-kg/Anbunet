using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Posts;

namespace Anbunet.Application.Features.Comments.Update;

public class UpdateCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IUnitOfWork unitOfWork
        //IMapper mapper
    )
    : ICommandHandler<UpdateCommentCommand, Result>
{
    public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdWithInclude(request.Data.CommentId);
        if (comment is null) return Result.Failure(CommentErrors.CommentNotFound);

        comment.Text = request.Data.Text;

        commentRepository.Update(comment);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}