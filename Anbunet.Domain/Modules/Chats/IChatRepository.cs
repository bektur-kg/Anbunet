﻿using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;

namespace Anbunet.Domain.Modules.Chats;

public interface IChatRepository : IRepository<PrivateMessage>
{

}
