using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using AutoMapper;

namespace Anbunet.Application.Features.Posts.GetById;

public class GetPostByIdQueryHandler 
    (
        IPostRepository postRepository,
        IMapper mapper
    )
    : IQueryHandler<GetPostByIdQuery, ValueResult<PostDetailedResponse>>
{
    public async Task<ValueResult<PostDetailedResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdWithInclude(request.Id, includeComments: true, includeLikes: true, includeUser: true);

        if (foundPost is null) return ValueResult<PostDetailedResponse>.Failure(PostErrors.PostNotFound);

        var mappedPost = mapper.Map<PostDetailedResponse>(foundPost);

        return ValueResult<PostDetailedResponse>.Success(mappedPost);
    }
}

