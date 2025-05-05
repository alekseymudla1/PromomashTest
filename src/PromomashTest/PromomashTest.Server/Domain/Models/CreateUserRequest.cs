namespace PromomashTest.Server.Domain.Models;

public class CreateUserRequest
{
    public string Email { get; set; }

    public string Password { get; set; }

    public bool ConfirmationGiven { get; set; }

    public int CountryId { get; set; }

    public int ProvinceId { get; set; }
}
