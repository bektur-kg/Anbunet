using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts.GetById;

public record GetPostByIdQuery(long Id) : IQuery<ValueResult<PostDetailedResponse>>;

