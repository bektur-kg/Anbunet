using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Likes.Create;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Likes.GetAll;

public class GetAllLikeCommandHandler
    (
        IPostRepository postRepository
    )
    : ICommandHandler<GetAllLikeCommand, ValueResult<int>>
{

    public async Task<ValueResult<int>> Handle(GetAllLikeCommand request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdWithIncludeAndTracking(request.PostId, includeLikes: true);

        if (foundPost is null) return ValueResult<int>.Failure(PostErrors.PostNotFound);

        var numberOfLikes= foundPost.Likes.Count;

        return ValueResult<int>.Success(numberOfLikes);
    }
}
