using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Users;

namespace Anbunet.Domain.Modules.Posts;

public class Post : Entity
{
    public long UserId { get; set; }

    [Url]
    public required string MediaUrl { get; set; }

    [MaxLength(PostAttributeConstants.MAX_DESCRIPTION_LENGTH)]
    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public User? User { get; set; }

    public List<Comment> Comments { get; set; } = [];

    public List<Like> Likes { get; set; } = [];
}

