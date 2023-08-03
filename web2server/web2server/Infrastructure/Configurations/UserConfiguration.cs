using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using web2server.Models;

namespace web2server.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Username).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Birthdate).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(30);

        }
    }
}
