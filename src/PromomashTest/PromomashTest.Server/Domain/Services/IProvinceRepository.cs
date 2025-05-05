using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Domain.Services;

public interface IProvinceRepository
{
    Task<IEnumerable<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken);
}
