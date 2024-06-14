namespace Anbunet.Application.Features.Comments;

public class CommentMappings : Profile
{
    public CommentMappings()
    {
        CreateMap<Comment, CommentResponse>();

        CreateMap<Comment, CommentRequest>();
    }
}