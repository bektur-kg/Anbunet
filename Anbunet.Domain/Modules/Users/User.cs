using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Stories;

namespace Anbunet.Domain.Modules.Users;

public class User : Entity
{
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
    public string? Email { get; set; }
    public string? Fullname { get; set; }
    public string? ProfilePicture { get; set; }
    public string? Bio { get; set; }
    public Gender Gender { get; set; } = Gender.None;
    public DateTime CreatedDate { get; } = DateTime.UtcNow;

    public List<Post> Posts { get; set; } = [];
    public List<User> Followers { get; set; } = [];
    public List<User> Followings { get; set; } = [];
    public List<Like> Likes { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    public List<Story> Stories { get; set; } = [];
}

