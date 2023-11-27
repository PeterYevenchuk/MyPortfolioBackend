using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Educations;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations", "public");

        builder.HasKey(e => e.EducationID);
        builder.Property(e => e.EducationID)
            .ValueGeneratedOnAdd(); 

        builder.Property(e => e.Rang)
            .HasMaxLength(255) 
            .IsRequired(); 

        builder.Property(e => e.Speciality)
            .HasMaxLength(255) 
            .IsRequired();

        builder.Property(e => e.University)
            .HasMaxLength(255) 
            .IsRequired(); 

        builder.Property(e => e.DateStart)
            .HasColumnType("date") 
            .IsRequired(); 

        builder.Property(e => e.DateFinish)
            .HasColumnType("date"); 

        builder.Property(e => e.Description)
            .HasMaxLength(1000); 

        builder.Property(e => e.AboutMeID); 

        builder.HasOne(e => e.AboutMe)
            .WithMany(am => am.Educations)
            .HasForeignKey(e => e.AboutMeID); 
    }
}
