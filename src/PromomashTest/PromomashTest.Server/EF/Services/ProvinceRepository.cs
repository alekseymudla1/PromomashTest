using Microsoft.EntityFrameworkCore;
using PromomashTest.Server.Domain.Models;
using PromomashTest.Server.Domain.Services;

namespace PromomashTest.Server.EF.Services;

public class ProvinceRepository : IProvinceRepository
{
    private readonly AppDbContext _dbContext;

    public ProvinceRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Province>> GetProvincesByCountryAsync(int countryId, CancellationToken cancellationToken)
    {
        return await _dbContext.Provinces
            .Where(p => p.CountryId == countryId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
