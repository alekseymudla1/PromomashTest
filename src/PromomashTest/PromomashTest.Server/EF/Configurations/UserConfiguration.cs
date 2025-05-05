using Microsoft.EntityFrameworkCore;
using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.EF.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName).HasColumnType("varchar(200)").IsRequired();
        builder.Property(u => u.Email).HasColumnType("varchar(200)").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnType("varchar(1000)").IsRequired();

        builder.Property(u => u.CountryId).IsRequired();
        builder.Property(u => u.ProvinceId).IsRequired();

        builder.HasOne<Country>()
            .WithMany()
            .HasForeignKey(u => u.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Province>()
            .WithMany()
            .HasForeignKey(u => u.ProvinceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
