using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.Educations;
using MyPortfolio.Core.Experiences;
using MyPortfolio.Core.Projects;
using MyPortfolio.Core.Skills;
using MyPortfolio.Core.SocialLinks;

namespace MyPortfolio.Core.InfoAboutMe;

public class AboutMeViewModel
{
    public int AboutMeID { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public byte Age { get; set; }

    public string Location { get; set; }

    public string Position { get; set; }

    public string PhotoMeUrl { get; set; }

    public string Description { get; set; }

    public List<SocialLinkViewModel>? Links { get; set; }

    public List<SkillViewModel>? Skills { get; set; }

    public List<ProjectViewModel>? Projects { get; set; }

    public List<ExperienceViewModel>? Experiences { get; set; }

    public List<EducationViewModel>? Educations { get; set; }

    public List<CertificateViewModel>? Certificates { get; set; }
}
