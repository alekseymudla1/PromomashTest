using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Controllers.Models;

public class ProvinceDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public int CountryId { get; set; }

    public ProvinceDto(Province province)
    {
        Id = province.Id;
        Name = province.Name;
        CountryId = province.CountryId;
    }
}
