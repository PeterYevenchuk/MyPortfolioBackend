using AutoMapper;
using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.Educations;
using MyPortfolio.Core.Experiences;
using MyPortfolio.Core.InfoAboutMe;
using MyPortfolio.Core.Projects;
using MyPortfolio.Core.Skills;
using MyPortfolio.Core.SocialLinks;

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
    }
}
