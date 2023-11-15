using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPortfolio.Core.Users;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "public");

        builder.HasKey(sl => sl.UserID);
        builder.Property(sl => sl.UserID)
            .ValueGeneratedOnAdd();

        builder.Property(sl => sl.Login)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(sl => sl.Login)
            .IsUnique();

        builder.Property(sl => sl.Password)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(sl => sl.Salt)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(sl => sl.Role)
            .IsRequired();
    }
}
