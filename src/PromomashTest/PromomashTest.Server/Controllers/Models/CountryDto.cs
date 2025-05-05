using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Controllers.Models;

public class CountryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public CountryDto(Country country)
    {
        Id = country.Id;
        Name = country.Name;
    }
}
