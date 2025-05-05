using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public interface ILocationService
{
    Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken);

    Task<Country> GetCountryByIdAsync(int countryId, CancellationToken cancellationToken);

    Task<IEnumerable<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken);
}
