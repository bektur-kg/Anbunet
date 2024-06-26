﻿namespace Anbunet.Domain.Modules.Likes;

public class Like : Entity
{
    public long PostId { get; set; }

    public long? UserId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public Post? Post { get; set; }

    public User? User { get; set; }
}