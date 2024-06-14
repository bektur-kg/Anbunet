namespace Anbunet.Application.Features.Likes.GetAll;

public record GetAllLikeQuery(long PostId) : ICommand<ValueResult<List<LikeResponse>>>;