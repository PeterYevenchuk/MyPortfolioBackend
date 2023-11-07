using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.InfoAboutMe;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class AboutMeConfiguration : IEntityTypeConfiguration<AboutMe>
{
    public void Configure(EntityTypeBuilder<AboutMe> builder)
    {
        builder.ToTable("AboutMe", "public");

        builder.HasKey(a => a.AboutMeID);
        builder.Property(a => a.AboutMeID)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.Surname)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.Age)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(a => a.Location)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.Position)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.PhotoMeUrl)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.Description)
            .HasMaxLength(1000)
            .IsRequired();
    }
}
