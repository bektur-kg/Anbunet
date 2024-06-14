namespace Anbunet.Application.Features.Posts.Update;

public class UpdatePostCommandHandler
    (
        IPostRepository postRepository,
        IUnitOfWork unitOfWork,
        IFileProvider fileProvider
    )
    : ICommandHandler<UpdatePostCommand, Result>
{

    public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetByIdWithIncludeAndTrackingAsync(request.Id);
        if (post == null) return Result.Failure(PostErrors.PostNotFound);

        if (request.Data.File != null)
        {
            await fileProvider.DeleteAsync(post.MediaUrl);
            var result = await fileProvider.CreateAsync(request.Data.File, cancellationToken);

            if (!result.IsSuccess) return Result.Failure(result.Error);
            post.MediaUrl = result.Value;
        }

        if(!request.Data.Description.IsNullOrEmpty()) post.Description = request.Data.Description;

        postRepository.Update(post);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}