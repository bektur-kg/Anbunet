using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Stories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Stories.GetMyselfStories;

public class GetMyselfStoriesQueryHandler
    (
        IStoryRepository storyRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
    )
    : IQueryHandler<GetMyselfStoriesQuery, ValueResult<List<ProfileStoryResponse>>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<List<ProfileStoryResponse>>> Handle(GetMyselfStoriesQuery request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var stories = await storyRepository.GetStoriesByUserIdAsync(userId);
        var mappedStories = mapper.Map<List<ProfileStoryResponse>>(stories);
        return ValueResult<List<ProfileStoryResponse>>.Success(mappedStories);
    }
}