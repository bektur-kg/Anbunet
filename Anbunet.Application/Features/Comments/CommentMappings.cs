using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Modules.Comments;
using AutoMapper;

namespace Anbunet.Application.Features.Comments;

public class CommentMappings : Profile
{
    public CommentMappings()
    {
        CreateMap<Comment, CommentResponse>();
    }
}

