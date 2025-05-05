using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken);

    Task<Country> GetCountryByIdAsync(int countryId, CancellationToken cancellationToken);
}
