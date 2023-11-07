using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Skills;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills", "public");

        builder.HasKey(s => s.SkillID);
        builder.Property(s => s.SkillID)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.MySkill)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(s => s.AboutMeID);

        builder.HasOne(s => s.AboutMe)
            .WithMany(am => am.Skills)
            .HasForeignKey(s => s.AboutMeID);
    }
}
