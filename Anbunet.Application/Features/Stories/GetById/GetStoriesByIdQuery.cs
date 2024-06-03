using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Stories.GetById;

public record GetStoriesByIdQuery(long Id) : ICommand<ValueResult<ProfileStoryResponse>>;