using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public interface IUsersService
{
    Task AddUserAsync(CreateUserRequest user);

    Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
