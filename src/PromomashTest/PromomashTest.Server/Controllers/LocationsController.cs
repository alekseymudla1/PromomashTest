using Microsoft.AspNetCore.Mvc;
using PromomashTest.Server.Controllers.Models;
using PromomashTest.Server.Domain.Services;

namespace PromomashTest.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("countries")]
    [ProducesResponseType(typeof(CountryDto[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
    {
        var countries = await _locationService.GetCountriesAsync(cancellationToken);
        return Ok(countries.Select(c => new CountryDto(c)));
    }

    [HttpGet("countries/{countryId}/provinces")]
    [ProducesResponseType(typeof(ProvinceDto[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProvincesByCountry(int countryId, CancellationToken cancellationToken)
    {
        var provinces = await _locationService.GetProvincesByCountryAsync(countryId, cancellationToken);
        return Ok(provinces.Select(p => new ProvinceDto(p)));
    }
}
