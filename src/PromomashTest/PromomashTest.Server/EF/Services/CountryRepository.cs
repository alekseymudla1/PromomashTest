using Microsoft.EntityFrameworkCore;
using PromomashTest.Server.Domain.Models;
using PromomashTest.Server.Domain.Services;

namespace PromomashTest.Server.EF.Services;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext _dbContext;

    public CountryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Countries
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Country> GetCountryByIdAsync(int countryId, CancellationToken cancellationToken)
    {
        return await _dbContext.Countries
            .Include(c => c.Provinces)
            .FirstOrDefaultAsync(c => c.Id == countryId, cancellationToken);
    }
}
