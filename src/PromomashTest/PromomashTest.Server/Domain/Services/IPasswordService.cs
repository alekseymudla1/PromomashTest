using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public interface IPasswordService
{
    string HashPassword(User user, string plainPassword);

    bool VerifyPassword(User user, string enteredPassword); 
}
