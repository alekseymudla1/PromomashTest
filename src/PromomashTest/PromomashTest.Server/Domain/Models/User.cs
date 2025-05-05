namespace PromomashTest.Server.Domain.Models;

public class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public bool ConfirmationGiven { get; set; }

    public int CountryId { get; set; }

    public int ProvinceId { get; set; }
}
