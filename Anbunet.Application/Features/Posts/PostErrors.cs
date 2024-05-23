using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts;

public abstract class PostErrors
{
    public static Error NotSupportedFileExtensions = new("Post.NotSupportedFileExtensions", "We only support these extensions: .jpg, .mp4, .jpeg, .png");
    public static Error NotSupportedFileSize = new("Post.NotSupportedFileSize", "File size is too big, 20Mb is maximum.");

}

