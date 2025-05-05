using FluentValidation;
using PromomashTest.Server.Domain.Models;
using PromomashTest.Server.Domain.Services;
using PromomashTest.Server.EF.Services;
using PromomashTest.Server.Validation;

namespace PromomashTest.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDbMigrationService, DbMigrationService>();

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<ILocationService, LocationService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IValidator<CreateUserRequest>, UserValidator>();
    }
}
