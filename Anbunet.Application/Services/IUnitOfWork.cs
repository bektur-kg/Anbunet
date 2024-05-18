namespace Anbunet.Application.Services;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}