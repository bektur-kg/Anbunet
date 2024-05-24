﻿using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts;

public abstract class PostErrors
{
    public static readonly Error NotSupportedFileExtensions = new("Post.NotSupportedFileExtensions", "We only support these extensions: .jpg, .mp4, .jpeg, .png");
    public static readonly Error NotSupportedFileSize = new("Post.NotSupportedFileSize", "File size is too big, 20Mb is maximum.");
    public static readonly Error PostNotFound = new("Post.PostNotFound", "Post is not found");
    public static readonly Error UserHasAlreadyLiked = new("Post.UserHasAlreadyLiked", "This user has already liked this post");
}

