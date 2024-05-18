using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;

namespace Anbunet.Domain.Modules.Comments;

public class Comment : Entity
{
    public long PostId { get; set; }
    public long? UserId { get; set; }
    public required string Text { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Post? Post { get; set; }
    public User? User { get; set; }
}

