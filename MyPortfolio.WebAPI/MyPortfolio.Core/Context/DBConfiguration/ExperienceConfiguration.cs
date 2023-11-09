using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Experiences;

namespace MyPortfolio.Core.Context.DBConfiguration;

internal class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences", "public");

        builder.HasKey(e => e.ExperienceID);
        builder.Property(e => e.ExperienceID)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Place)
            .HasMaxLength(255) 
            .IsRequired();

        builder.Property(e => e.Company)
            .HasMaxLength(255) 
            .IsRequired();

        builder.Property(e => e.Position)
            .HasMaxLength(255) 
            .IsRequired();

        builder.Property(e => e.Rang)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.DateStart)
            .HasColumnType("date") 
            .IsRequired(); 

        builder.Property(e => e.DateFinish)
            .HasColumnType("date"); 

        builder.Property(e => e.Description)
            .HasMaxLength(1000)
            .IsRequired(); 

        builder.Property(e => e.AboutMeID); 

        builder.HasOne(e => e.AboutMe)
            .WithMany(am => am.Experiences)
            .HasForeignKey(e => e.AboutMeID);
    }
}
