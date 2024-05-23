using Anbunet.Domain.Modules.Posts;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;

namespace Anbunet.Infrastructure.Modules.Posts;

public class PostRepository(AppDbContext dbContext) : Repository<Post>(dbContext), IPostRepository;

