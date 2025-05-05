using Microsoft.EntityFrameworkCore;
using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.EF.Configurations;

public class ProvincesConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("Provinces");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnType("varchar(200)");
        builder.Property(p => p.CountryId).IsRequired();
        builder.HasOne(p => p.Country)
            .WithMany(c => c.Provinces)
            .HasForeignKey(p => p.CountryId);

        builder.HasData(
            new Province() { Id = 1, Name = "California", CountryId = 1 },
            new Province() { Id = 2, Name = "Texas", CountryId = 1 },
            new Province() { Id = 3, Name = "Ontario", CountryId = 2 },
            new Province() { Id = 4, Name = "Quebec", CountryId = 2 },
            new Province() { Id = 5, Name = "Bavaria", CountryId = 3 },
            new Province() { Id = 6, Name = "Berlin", CountryId = 3 }
        );
    }
}
