using AutoMapper;
using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.Educations;
using MyPortfolio.Core.Educations.Save;
using MyPortfolio.Core.Experiences;
using MyPortfolio.Core.Experiences.Save;
using MyPortfolio.Core.InfoAboutMe;
using MyPortfolio.Core.Projects;
using MyPortfolio.Core.Projects.Save;
using MyPortfolio.Core.Skills;
using MyPortfolio.Core.Skills.Save;
using MyPortfolio.Core.SocialLinks;
using MyPortfolio.Core.SocialLinks.Save;

namespace MyPortfolio.Core;

public class CoreMappingsProfile : Profile
{
    public CoreMappingsProfile()
    {
        CreateMap<AboutMe, AboutMeViewModel>()
            .ForMember(dest => dest.PhotoMeUrl, opt => opt.Ignore())
            .ForMember(dest => dest.Links, opt => opt.Ignore())
            .ForMember(dest => dest.Skills, opt => opt.Ignore())
            .ForMember(dest => dest.Projects, opt => opt.Ignore())
            .ForMember(dest => dest.Experiences, opt => opt.Ignore())
            .ForMember(dest => dest.Educations, opt => opt.Ignore())
            .ForMember(dest => dest.Certificates, opt => opt.Ignore());

        CreateMap<SocialLink, SocialLinkViewModel>();

        CreateMap<Skill, SkillViewModel>();

        CreateMap<Project, ProjectViewModel>()
            .ForMember(dest => dest.PhotoProjectUrl, opt => opt.Ignore());

        CreateMap<Experience, ExperienceViewModel>();

        CreateMap<Education, EducationViewModel>();

        CreateMap<Certificate, CertificateViewModel>();

        CreateMap<AddEducationCommand, Education>();

        CreateMap<AddExperienceCommand, Experience>();

        CreateMap<AddProjectCommand, Project>()
            .ForMember(dest => dest.PhotoProjectUrl, opt => opt.Ignore());

        CreateMap<AddSkillCommand, Skill>();

        CreateMap<AddSocialLinkCommand, SocialLink>();
    }
}
