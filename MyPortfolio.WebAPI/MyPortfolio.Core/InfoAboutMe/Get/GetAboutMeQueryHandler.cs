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
        var info = await _context.AboutMe
            .Include(a => a.SocialLinks)
            .Include(a => a.Skills)
            .Include(a => a.Projects)
            .Include(a => a.Experiences)
            .Include(a => a.Educations)
            .Include(a => a.Certificates)
            .FirstOrDefaultAsync();

        if (info == null)
        {
            throw new ArgumentException("Not found!");
        }

        var result = _mapper.Map<AboutMeViewModel>(info);
        result.PhotoMeUrl = ConvertingPhoto(info.PhotoMeUrl);
        result.Links = _mapper.Map<List<SocialLinkViewModel>>(info.SocialLinks);
        result.Skills = _mapper.Map<List<SkillViewModel>>(info.Skills);
        result.Experiences = _mapper.Map<List<ExperienceViewModel>>(info.Experiences);
        result.Educations = _mapper.Map<List<EducationViewModel>>(info.Educations);
        result.Certificates = _mapper.Map<List<CertificateViewModel>>(info.Certificates);

        if (info.Projects != null && info.Projects.Any())
        {
            foreach (var project in info.Projects)
            {
                project.PhotoProjectUrl = ConvertingPhoto(project.PhotoProjectUrl);

            }
        }

        result.Projects = _mapper.Map<List<ProjectViewModel>>(info.Projects);

        return result;
    }

    private string ConvertingPhoto(string namePhoto)
    {
        string photoFolderPath = "wwwroot/images";

        string mePhotoFilePath = Path.Combine(photoFolderPath, namePhoto);

        if (File.Exists(mePhotoFilePath))
        {
            byte[] photoBytes = File.ReadAllBytes(mePhotoFilePath);
            string base64Photo = Convert.ToBase64String(photoBytes);

            return base64Photo;
        }
        else
        {
            throw new ArgumentException("Photo not found!");
        }
    }
}
