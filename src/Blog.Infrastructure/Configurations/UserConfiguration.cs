using Blog.Core.Entities;
using Blog.Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(x => x.PetProjects)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        builder
            .HasMany(x => x.Certificates)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        builder
            .HasMany(x => x.FileCvs)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder
            .HasMany(x => x.RefreshTokens)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder
            .HasData(new User()
            {
                 FirstName = "Azimjon",
                 LastName = "Shodiyorov",
                 Email = "azimjonshodiyorov@gmail.com",
                 Gender = Gender.Male,
                 BirthDate = new DateOnly(2000,01,27),
                 PhoneNumber = "+998942869775",
                 Password = "qwert12345",
                 CreateAt = DateTime.Now
            });

    }
}