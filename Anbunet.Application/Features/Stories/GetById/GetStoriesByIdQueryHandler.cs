using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Stories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Anbunet.Application.Features.Stories.GetById;

public class GetStoriesByIdQueryHandler
    (
        IStoryRepository storyRepository,
        IMapper mapper
    )
    : IQueryHandler<GetStoriesByIdQuery, ValueResult<ProfileStoryResponse>>
{
    public async Task<ValueResult<ProfileStoryResponse>> Handle(GetStoriesByIdQuery request, CancellationToken cancellationToken)
    {
        var stories = await storyRepository.GetByIdAsync(request.Id);

        if (stories == null) return ValueResult<ProfileStoryResponse>.Failure(StoriesErrors.StoriesNotFound);

        var mappedStories = mapper.Map<ProfileStoryResponse>(stories);
        
        return ValueResult<ProfileStoryResponse>.Success(mappedStories);
    }
}