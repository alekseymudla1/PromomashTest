using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public interface IUserRepository
{
    Task AddUserAsync(User user, CancellationToken cancellationToken);

    Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
