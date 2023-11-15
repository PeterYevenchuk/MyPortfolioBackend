using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Certificates.Delete;
using MyPortfolio.Core.Educations.Delete;
using MyPortfolio.Core.Experiences.Delete;
using MyPortfolio.Core.Projects.Delete;
using MyPortfolio.Core.Skills.Delete;
using MyPortfolio.Core.SocialLinks.Delete;

namespace MyPortfolio.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminDeleteController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminDeleteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-certificate/{id}")]
    public async Task<IActionResult> DeleteCertificate(int id)
    {
        var request = new DeleteCertificateCommand { CertificateID = id };
        await _mediator.Send(request);

        return Ok("Certificate removed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-education/{id}")]
    public async Task<IActionResult> DeleteEducation(int id)
    {
        var request = new DeleteEducationCommand { EducationID = id };
        await _mediator.Send(request);

        return Ok("Education removed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-experience/{id}")]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        var request = new DeleteExperianceCommand { ExperienceID = id };
        await _mediator.Send(request);

        return Ok("Experience removed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-project/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var request = new DeleteProjectCommand { ProjectID = id };
        await _mediator.Send(request);

        return Ok("Project removed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-skill/{id}")]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        var request = new DeleteSkillCommand { SkillID = id };
        await _mediator.Send(request);

        return Ok("Skill removed successfully.");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("delete-social-link/{id}")]
    public async Task<IActionResult> DeleteSocialLink(int id)
    {
        var request = new DeleteSocialLinkCommand { SocialLinkID = id };
        await _mediator.Send(request);

        return Ok("Social link removed successfully.");
    }
}
