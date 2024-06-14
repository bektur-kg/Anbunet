namespace Anbunet.Application.Features.Stories.GetById;

public record GetStoriesByIdQuery(long Id) : IQuery<ValueResult<ProfileStoryResponse>>;