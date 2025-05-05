namespace PromomashTest.Server.EF.Services;

public interface IDbMigrationService
{
    Task MigrateAsync();
}
