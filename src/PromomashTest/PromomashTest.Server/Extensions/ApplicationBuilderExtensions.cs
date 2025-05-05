using PromomashTest.Server.EF.Services;

namespace PromomashTest.Server.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseDatabaseMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<IDbMigrationService>().MigrateAsync().Wait();
        }
    }
}
