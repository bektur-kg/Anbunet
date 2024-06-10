using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Stories.GetMyselfStories;

public record GetMyselfStoriesQuery : IQuery<ValueResult<List<ProfileStoryResponse>>>;