using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;

namespace Anbunet.Application.Features.Posts.Delete;

public class DeletePostCommandHandler
    (
        IPostRepository postRepository,
        IUnitOfWork unitOfWork,
        IFileProvider fileProvider
    )
    : ICommandHandler<DeletePostCommand, Result>
{
    public async Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetByIdWithInclude(request.Id);

        if (post == null) return Result.Failure(PostErrors.PostNotFound);

        await fileProvider.Delete(post.MediaUrl);
        postRepository.Remove(post);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}