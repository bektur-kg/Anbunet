using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;

namespace Anbunet.Application.Features.Posts;

public abstract class PostErrors
{
    public static readonly Error NotSupportedFileExtensions = new("Post.NotSupportedFileExtensions", "We only support these extensions: .jpg, .mp4, .jpeg, .png");
    public static readonly Error NotSupportedFileSize = new("Post.NotSupportedFileSize", "File size is too big, 20Mb is maximum.");
    public static readonly Error FileNotFound = new("Post.FileNotFound", "File not found.");
    public static readonly Error ThisIsNotPostOfThisUser = new("Post.ThisIsNotPostOfThisUser", "This is not post of this user.");
    public static readonly Error PostNotFound = new("Post.PostNotFound", "Post is not found");
    public static readonly Error UserHasAlreadyLiked = new("Post.UserHasAlreadyLiked", "This user has already liked this post");
    public static readonly Error UserDidNotLikeIt = new ("Post.UserDidNotLikeIt", "This user did not like it");
}