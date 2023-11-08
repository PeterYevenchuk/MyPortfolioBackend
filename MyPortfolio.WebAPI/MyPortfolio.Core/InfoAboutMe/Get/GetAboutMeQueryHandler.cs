using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Certificates;
using MyPortfolio.Core.Context;
using MyPortfolio.Core.Educations;
using MyPortfolio.Core.Experiences;
using MyPortfolio.Core.Projects;
using MyPortfolio.Core.Skills;
using MyPortfolio.Core.SocialLinks;

namespace MyPortfolio.Core.InfoAboutMe.Get;

public class GetAboutMeQueryHandler : IRequestHandler<GetAboutMeQuery, AboutMeViewModel>
{
    private readonly MyPortfolioDbContext _context;
    private readonly IMapper _mapper;

    public GetAboutMeQueryHandler(MyPortfolioDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AboutMeViewModel> Handle(GetAboutMeQuery request, CancellationToken cancellationToken)
    {
        string photoFolderPath = "wwwroot/images";
        string base64MePhoto = "";

        var info = await _context.AboutMe.FirstOrDefaultAsync();

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        string mePhotoFilePath = Path.Combine(photoFolderPath, info.PhotoMeUrl);

        if (File.Exists(mePhotoFilePath))
        {
            byte[] photoBytes = File.ReadAllBytes(mePhotoFilePath);
            base64MePhoto = Convert.ToBase64String(photoBytes);
        }
        else
        {
            throw new ArgumentException("Photo not found!");
        }

        var result = _mapper.Map<AboutMeViewModel>(info);
        result.PhotoMeUrl = base64MePhoto;
        result.Links = _mapper.Map<List<SocialLinkViewModel>>(info.SocialLinks);
        result.Skills = _mapper.Map<List<SkillViewModel>>(info.Skills);
        result.Projects = _mapper.Map<List<ProjectViewModel>>(info.Projects);
        result.Experiences = _mapper.Map<List<ExperienceViewModel>>(info.Experiences);
        result.Educations = _mapper.Map<List<EducationViewModel>>(info.Educations);
        result.Certificates = _mapper.Map<List<CertificateViewModel>>(info.Certificates);

        return result;
    }
}
