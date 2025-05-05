using Microsoft.EntityFrameworkCore;

namespace PromomashTest.Server.EF.Services;
public class DbMigrationService : IDbMigrationService
{
    private readonly IConfigurationRoot _configurationRoot;
    private readonly AppDbContext _dbContext;

    public DbMigrationService(
        IConfiguration configuration,
        AppDbContext dbContext)
    {
        _configurationRoot = (IConfigurationRoot)configuration;
        _dbContext = dbContext;
    }

    public async Task MigrateAsync()
    {
        await _dbContext.Database.MigrateAsync();
    }
}
