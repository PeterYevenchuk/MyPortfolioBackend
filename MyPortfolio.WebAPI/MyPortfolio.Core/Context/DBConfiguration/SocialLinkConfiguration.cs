using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.SocialLinks;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class SocialLinkConfiguration : IEntityTypeConfiguration<SocialLink>
{
    public void Configure(EntityTypeBuilder<SocialLink> builder)
    {
        builder.ToTable("SocialLinks", "public"); 

        builder.HasKey(sl => sl.SocialLinkID); 
        builder.Property(sl => sl.SocialLinkID)
            .ValueGeneratedOnAdd();

        builder.Property(sl => sl.Name)
            .HasMaxLength(255) 
            .IsRequired(); 

        builder.Property(sl => sl.URL)
            .HasMaxLength(255) 
            .IsRequired();

        builder.Property(sl => sl.AboutMeID); 

        builder.HasOne(sl => sl.AboutMe)
            .WithMany(am => am.SocialLinks)
            .HasForeignKey(sl => sl.AboutMeID); 
    }
}
