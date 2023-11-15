using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.Context.DBConfiguration;
using MyPortfolio.Core.Context.Seeds;
using MyPortfolio.Core.Educations;
using MyPortfolio.Core.Experiences;
using MyPortfolio.Core.InfoAboutMe;
using MyPortfolio.Core.Projects;
using MyPortfolio.Core.Skills;
using MyPortfolio.Core.SocialLinks;
using MyPortfolio.Core.Users;

namespace MyPortfolio.Core.Context;

public class MyPortfolioDbContext : DbContext
{
    public MyPortfolioDbContext(DbContextOptions<MyPortfolioDbContext> options) : base(options) { }

    public DbSet<AboutMe> AboutMe { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();

        modelBuilder.ApplyConfiguration(new AboutMeConfiguration());
        modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        modelBuilder.ApplyConfiguration(new SocialLinkConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new EducationConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        DataSeeder.SeedData(modelBuilder);
    }
}
