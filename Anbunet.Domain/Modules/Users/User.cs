using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Stories;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Domain.Modules.Users;

public class User : Entity
{
    [MaxLength(UserAttributeConstants.MAX_LOGIN_LENGTH)]
    public required string Login { get; set; }

    public required string PasswordHash { get; set; }

    [EmailAddress]
    [MaxLength(UserAttributeConstants.MAX_EMAIL_LENGTH)]
    public string? Email { get; set; }

    [MaxLength(UserAttributeConstants.MAX_FULLNAME_LENGTH)]
    public string? Fullname { get; set; }

    [Url]
    public string? ProfilePicture { get; set; }

    [MaxLength(UserAttributeConstants.MAX_BIO_LENGTH)]
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

