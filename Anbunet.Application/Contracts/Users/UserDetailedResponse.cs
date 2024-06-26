﻿namespace Anbunet.Application.Contracts.Users;

public record UserDetailedResponse
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public string? Email { get; set; }

    public string? Fullname { get; set; }

    public string? ProfilePicture { get; set; }

    public string? Bio { get; set; }

    public Gender Gender { get; set; } = Gender.None;

    public DateTime CreatedDate { get; set; }

    public long FollowersCount { get; set; }

    public long FollowingsCount { get; set; }

    public List<ProfilePostResponse> Posts { get; set; } = [];

    public List<ProfileActualResponse> Actuals { get; set; } = [];
}