using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public class LocationService : ILocationService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IProvinceRepository _provinceRepository;

    public LocationService(ICountryRepository countryRepository, IProvinceRepository provinceRepository)
    {
        _countryRepository = countryRepository;
        _provinceRepository = provinceRepository;
    }

    public async Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await _countryRepository.GetCountriesAsync(cancellationToken);
    }

    public async Task<Country> GetCountryByIdAsync(int countryId, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetCountryByIdAsync(countryId, cancellationToken);
    }

    public async Task<IEnumerable<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken)
    {
        return await _provinceRepository.GetProvincesByCountryAsync(countryId, cancellationToken);
    }
}
