using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public UsersService(IUserRepository userRepository,
        IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task AddUserAsync(CreateUserRequest user)
    {
        var newUser = new User
        {
            UserName = user.Email,
            Email = user.Email,
            ConfirmationGiven = user.ConfirmationGiven,
            CountryId = user.CountryId,
            ProvinceId = user.ProvinceId,
        };

        var passwordHash = _passwordService.HashPassword(newUser, user.Password);
        newUser.PasswordHash = passwordHash;

        await _userRepository.AddUserAsync(newUser, CancellationToken.None);
    }

    public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserByEmailAsync(email, cancellationToken);
    }
}
