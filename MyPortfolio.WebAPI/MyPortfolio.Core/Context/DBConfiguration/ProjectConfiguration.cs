using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Projects;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects", "public");

        builder.HasKey(p => p.ProjectID);
        builder.Property(p => p.ProjectID)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired(); 

        builder.Property(p => p.PhotoProjectUrl)
            .HasMaxLength(255) 
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(p => p.GitHubUrl)
            .HasMaxLength(255);

        builder.Property(p => p.AboutMeID);

        builder.HasOne(p => p.AboutMe)
            .WithMany(am => am.Projects)
            .HasForeignKey(p => p.AboutMeID);
    }
}
