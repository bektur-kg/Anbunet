using Anbunet.Domain.Modules.Users;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Users;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository;

