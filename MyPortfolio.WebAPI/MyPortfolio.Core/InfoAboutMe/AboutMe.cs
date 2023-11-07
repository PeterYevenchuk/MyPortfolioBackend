using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyPortfolio.Core.Experiences;
using MyPortfolio.Core.Skills;
using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.SocialLinks;
using MyPortfolio.Core.Projects;
using MyPortfolio.Core.Educations;

namespace MyPortfolio.Core.InfoAboutMe;

public class AboutMe
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AboutMeID { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public byte Age {  get; set; }

    public string Location { get; set; }

    public string Position { get; set; }

    public string PhotoMeUrl { get; set; }

    public string Description { get; set; }

    public List<Experience> Experiences { get; set; }

    public List<Skill> Skills { get; set; }

    public List<Certificate> Certificates { get; set; }

    public List<SocialLink> SocialLinks { get; set; }

    public List<Project> Projects { get; set; }

    public List<Education> Educations { get; set; }
}
