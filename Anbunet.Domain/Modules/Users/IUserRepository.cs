﻿using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByLoginAsync(string login);
    Task<List<User>> GetUsersByLoginAsync(string login);
    Task<User?> GetByIdWithIncludeAsync(long userId, bool includePosts = false, bool includeFollowers = false, bool includeFollowings = false,
        bool includeLikes = false, bool includeComments = false, bool includeActuals = false, bool includeStories = false);
}
