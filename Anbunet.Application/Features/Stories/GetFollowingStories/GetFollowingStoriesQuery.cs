using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Stories.GetAllStories;

public record GetFollowingStoriesQuery : IQuery<ValueResult<List<FollowingStoriesResponse>>>;