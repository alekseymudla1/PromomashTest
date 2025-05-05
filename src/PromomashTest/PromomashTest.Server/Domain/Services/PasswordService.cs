using Microsoft.AspNetCore.Identity;
using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public class PasswordService : IPasswordService
{
    private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

    public string HashPassword(User user, string plainPassword)
    {
        return _hasher.HashPassword(user, plainPassword);
    }

    public bool VerifyPassword(User user, string enteredPassword)
    {
        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, enteredPassword);
        return result == PasswordVerificationResult.Success;
    }
}

