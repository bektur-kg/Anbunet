using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Stories.GetUserStories;

public record GetUserStoriesQuery(long UserId) : IQuery<ValueResult<List<ProfileStoryResponse>>>;

