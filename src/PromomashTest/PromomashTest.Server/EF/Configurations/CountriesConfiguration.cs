using Microsoft.EntityFrameworkCore;
using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.EF.Configurations;

public class CountriesConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasColumnType("varchar(200)");

        builder.HasData(
            new Country() { Id = 1, Name = "USA"},
            new Country() { Id = 2, Name = "Canada"},
            new Country() { Id = 3, Name = "Germany"}
        );
    }
}
